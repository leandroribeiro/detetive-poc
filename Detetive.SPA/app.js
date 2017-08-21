class Form {

    constructor(data) {
        this.originalData = data;

        for (let field in data) {
            this[field] = data[field];
        }
    }

    reset() {
        for (let field in this.originalData) {
            this[field] = '';
        }
    }

    data() {
        let data = {};

        for (let property in this.originalData) {
            data[property] = this[property];
        }

        //delete data.errors;

        return data;
    }

}

var vm = new Vue({
    el: '#app',

    data: {
        form: new Form({
            caso: {
                id: 0,
                dataAbertura: ''
            },
    
            armaSelecionada: 0,
            armas: [],
    
            localSelecionado: 0,
            locais: [],
    
            suspeitoSelecionado: 0,
            suspeitos: [],
    
            resposta: -1
        })
        
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
                        casoID: this.form.caso.id,
                        armaID: this.form.armaSelecionada,
                        localID: this.form.localSelecionado,
                        suspeitoID: this.form.suspeitoSelecionado
                    }

                })
                .then(function (response) {
                    vm.form.resposta = response.data;
                    
                })
                .catch(function (error) {
                    console.log(error);

                });
        },

        carregarDados() {
            axios.get(`http://localhost:17762/api/caso/novo`)
                .then(response => {
                    this.form.caso = response.data;
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/arma`)
                .then(response => {
                    this.form.armas = response.data.map(x => {
                        return {
                            value: x.id,
                            text: x.nome
                        }
                    });
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/local`)
                .then(response => {
                    this.form.locais = response.data.map(x => {
                        return {
                            value: x.id,
                            text: x.nome
                        }
                    });
                })
                .catch(e => {
                    console.error(e);
                });

            axios.get(`http://localhost:17762/api/suspeito`)
                .then(response => {
                    this.form.suspeitos = response.data.map(x => {
                        return {
                            value: x.id,
                            text: x.nome
                        }
                    });
                })
                .catch(e => {
                    console.error(e);
                });
        }
    },

});