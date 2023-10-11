function Calcular() {
	event.preventDefault();

	let n1 = parseFloat(document.getElementById("n1").value);

	let n2 = parseFloat(document.getElementById("n2").value);

	
	let result = document.getElementById("result").innerHTML;

	let op = document.getElementById("op").value;

	switch (op) {
		case "soma":
			result = `Resultado: ${(n1 + n2).toFixed(2)}`;
			break;
		case "sub":
			result = `Resultado: ${(n1 - n2).toFixed(2)}`;
			break;
		case "mult":
			result = `Resultado: ${(n1 * n2).toFixed(2)}`;
			break;
		case "div":
			result = `Resultado: ${(n1 / n2).toFixed(2)}`;
			if (n2 == 0) result = "Não é possível dividir por 0!";
			break;
		default:
			result = "Selecione uma operação!";
			break;
	}

	if (isNaN(n1) || isNaN(n2)) result = "Preencha os campos corretamente!";
	if (n1.toString().includes(",") || n2.toString().includes(",")) result = "Preencha os campos corretamente!";

	document.getElementById("result").innerHTML = result;
}