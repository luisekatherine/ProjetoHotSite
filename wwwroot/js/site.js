//analisando nosso documento, onde vamos executar funções quando estiver pronto = carregado.
$(document).ready(
    function()
    {
        $("#frmCadastro").submit(
            function(e)
            {
                e.preventDefault(); //essa função encerra o envio de dados, cas dê algum erro.
                Cadastrar();
            }
            );
    }
    );

    function Cadastrar()
    {
        let parametros = { 
            Nome: $("#nome").val(),
            Email: $("#email").val(),
            Mensagem: $("#mensagem").val()
        };

        $.post("/Home/Cadastrar", parametros).done(
            function(data)
        {
            if(data.status == "OK")
            {
                $("#frmCadastro").after("<h3>Cadastro enviado com sucesso!</3>")
                $("#frmCadastro").hide();
            }
            else
            {
                alert(data.mensagem);
            }
        }).fail(function()
        {
            alert("Ocorreu um erro!")
        })
    }