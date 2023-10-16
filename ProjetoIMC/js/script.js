let usuarios = [];

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
	} else{
        return "Obesidade Mórbida";}
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
		nome: nome,
		altura: altura,
		peso: peso,
		valorImc: valorImc,
		classificacaoImc: classificacaoImc,
		dataDeCadastro: dataDeCadastro,
	};

	usuarios.push(usuario);

	document.getElementById("corpo-tabela").innerHTML += `
    <tr>
        <td data-cell="nome">${usuario.nome}</td>
        <td data-cell="altura">${usuario.altura}</td>
        <td data-cell="peso">${usuario.peso}</td>
        <td data-cell="valor do IMC">${usuario.valorImc}</td>
        <td data-cell="classificação do IMC">${usuario.classificacaoImc}</td>
        <td data-cell="data de cadastro">${usuario.dataDeCadastro}</td>
    </tr>
    `;
}

function deletarRegistros() {
	document.getElementById("corpo-tabela").innerHTML = "";

	usuarios = [];
}
