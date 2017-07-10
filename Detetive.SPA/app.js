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

        armaSelecionada: 0,
        armas: [],

        localSelecionado: 0,
        locais: [],

        suspeitoSelecionado: 0,
        suspeitos: []
    },


    methods: {
        interrogar() {
            alert('teste');
        }
    },

    created() {

        axios.get(`http://localhost:17762/api/arma`)
            .then(response => {
                // JSON responses are automatically parsed.
                this.armas = response.data.map(x => { return { id: x.id, text: x.nome } });
            })
            .catch(e => {
                //this.errors.push(e)
                console.error(e);
            });

        axios.get(`http://localhost:17762/api/local`)
            .then(response => {
                // JSON responses are automatically parsed.
                this.locais = response.data.map(x => { return { id: x.id, text: x.nome } });
            })
            .catch(e => {
                //this.errors.push(e)
                console.error(e);
            });

        axios.get(`http://localhost:17762/api/suspeito`)
            .then(response => {
                // JSON responses are automatically parsed.
                this.suspeitos = response.data.map(x => { return { id: x.id, text: x.nome } });
            })
            .catch(e => {
                //this.errors.push(e)
                console.error(e);
            });
    },


});