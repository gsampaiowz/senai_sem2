function Calcular() {
	event.preventDefault();

	let n1 = parseFloat(document.getElementById("n1").value);

	let n2 = parseFloat(document.getElementById("n2").value);

	let result = document.getElementById("result").innerHTML;

	let op = document.getElementById("op").value;

	switch (op) {
		case "soma":
			result = `Resultado: ${n1 + n2}`;
			break;
		case "sub":
			result = `Resultado: ${n1 - n2}`;
			break;
		case "mult":
			result = `Resultado: ${n1 * n2}`;
			break;
		case "div":
			result = `Resultado: ${n1 / n2}`;
			break;
		default:
			result = 'Selecione uma operação!';
			break;
	}

	document.getElementById("result").innerHTML = result;
}
