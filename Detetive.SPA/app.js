Vue.component('select2', {
    props: ['options', 'value'],

    template: '#select2-template',

    mounted: function () {
        var vm = this
        $(this.$el)
            // init select2
            .select2({ data: this.options })
            .val(this.value)
            .trigger('change')
            // emit event on change.
            .on('change', function () {
                vm.$emit('input', this.value)
                console.log(this.value);
            })
    },

    watch: {
        value: function (value) {
            // update value
            $(this.$el).val(value).trigger('change');
        },
        options: function (options) {
            // update options
            $(this.$el).select2({ data: options })
        }
    },

    destroyed: function () {
        $(this.$el).off().select2('destroy')
    }
})

var vm = new Vue({
    el: '#app',

    data: {

        caso: null,

        armaSelecionada: 0,
        armas: [],

        localSelecionado: 0,
        locais: [],

        suspeitoSelecionado: 0,
        suspeitos: [],

        resposta: -1
    },

    created() {
        this.carregarDados();
    },

    methods: {
        interrogar: function () {

            axios({
                method: 'post',
                url: 'http://localhost:17762/api/caso/interrogar',
                params: {
                    casoID: this.caso.id,
                    armaID: this.armaSelecionada,
                    localID: this.localSelecionado,
                    suspeitoID: this.suspeitoSelecionado
                }
            })
                .then(function (response) {
                    console.log(response);
                    console.log(response.data);
                    this.resposta = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },

        carregarDados() {
            axios.get(`http://localhost:17762/api/caso/novo`)
                .then(response => {
                    this.caso = response.data;
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/arma`)
                .then(response => {
                    this.armas = response.data.map(x => { return { id: x.id, text: x.nome } });
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/local`)
                .then(response => {
                    this.locais = response.data.map(x => { return { id: x.id, text: x.nome } });
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/suspeito`)
                .then(response => {
                    this.suspeitos = response.data.map(x => { return { id: x.id, text: x.nome } });
                })
                .catch(e => {
                    console.error(e);
                });
        }
    },

});