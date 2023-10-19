// const camisaNike = {
//     descricao: 'Camisa Nike Corinthians I',
//     preco: 229.9,
//     marca: 'Nike',
//     tamanho: 'G',
//     cor: 'Preta',
//     promocao: true, 
// }

// const { descricao, preco, promocao } = camisaNike;

// console.log(`
//     Descrição: ${descricao}
//     Preço: ${preco}
//     Promoção: ${promocao}`)

/* Crie um objeto evento com as propriedades
- dataEvento
- descricaoEvento
- titulo
- presenca
- comentario 
    Crie uma destructuring para as propriedades do objeto evento e as exiba no console.
    OBS: Para a presença deve-se exibir "sim" ou "não"
*/

const evento = {
    dataEvento: new Date(2021, 10, 20),
    descricaoEvento: 'Evento de jogos',
    titulo: 'Campeonato de LOL',
    presenca: true,
    comentario: 'Gostei muito do evento!'
}

const { dataEvento, descricaoEvento, titulo, presenca, comentario } = evento;

console.log(`
    Data do evento: ${dataEvento}
    Descrição do evento: ${descricaoEvento}
    Título: ${titulo}`)