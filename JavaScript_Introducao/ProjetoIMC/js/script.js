const usuarios = [];

function listarUsuarios() {
  let linhas;
  usuarios.forEach(function (oUsuario) {
    linhas += `<tr>
	<td data-cell="nome">${oUsuario.nome}</td>
	<td data-cell="altura">${oUsuario.altura}</td>
	<td data-cell="peso">${oUsuario.peso}</td>
	<td data-cell="valor do IMC">${oUsuario.valorImc}</td>
	<td data-cell="classificação do IMC">${oUsuario.classificacaoImc}</td>
	<td data-cell="data de cadastro">${oUsuario.dataDeCadastro}</td>
</tr>`;
  });

  document.getElementById("corpo-tabela").innerHTML = linhas;
}

function limparForm(){
  document.getElementById("nome").value = null;
  document.getElementById("altura").value = null;
  document.getElementById("peso").value = null;
}

function calcularImc(peso, altura) {
  return peso / altura ** 2;
}

function geraClassificacaoImc(valorImc) {
  if (valorImc < 18.5) {
    return "Magreza Severa";
  } else if (valorImc >= 18.5 && valorImc <= 24.9) {
    return "Peso normal";
  } else if (valorImc >= 25 && valorImc <= 29.9) {
    return "Acima do peso";
  } else if (valorImc >= 30 && valorImc <= 34.9) {
    return "Obesidade I";
  } else if (valorImc >= 35 && valorImc <= 39.9) {
    return "Obesidade II";
  } else {
    return "Obesidade Mórbida";
  }
}

function calcular(e) {
  e.preventDefault();

  let nome = document.getElementById("nome").value.trim();
  let altura = document.getElementById("altura").value;
  let peso = document.getElementById("peso").value;

  let valorImc = calcularImc(peso, altura);
  let classificacaoImc = geraClassificacaoImc(valorImc);
  let now = new Date();
  let dataDeCadastro = `${now.getDate()}/${now.getMonth()}/${now.getFullYear()} - ${now.getHours()}:${now.getMinutes()}`;

  if (isNaN(altura) || isNaN(peso) || nome.length < 2) {
    alert("Preencha corretamente os campos!");
    return;
  }

  let usuario = {
    nome,
    altura,
    peso,
    valorImc,
    classificacaoImc,
    dataDeCadastro,
  };

  usuarios.push(usuario);

  listarUsuarios();

  limparForm();
}

function deletarRegistros() {
  document.getElementById("corpo-tabela").innerHTML = "";

  usuarios = [];
}
