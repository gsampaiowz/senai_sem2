let sampaio = {
    nome: "Sampaio",
    idade: 18,
    altura: 1.70.toFixed(2),
    peso: 60,
}

sampaio.peso = 65;

console.log(sampaio);

let gustavo = new Object();

gustavo.nome = "Gustavo";
gustavo.idade = 18;
gustavo.altura = 1.75;
gustavo.peso = 70;

console.log(gustavo);

let pessoas = [];

pessoas.push(sampaio);
pessoas.push(gustavo);

console.log(pessoas);

pessoas.forEach(pessoa => {
    console.log(pessoa);
})

pessoas.forEach(function (p, i){
    console.log(`Pessoa ${i+1}: ${p.nome} | Idade: ${p.idade} | Altura: ${p.altura} | Peso: ${p.peso}`);
})