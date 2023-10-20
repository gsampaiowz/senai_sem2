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

const { dataEvento, descricaoEvento, titulo, ...resto} = evento;

console.log(`
    Data do evento: ${dataEvento}
    Descrição do evento: ${descricaoEvento}
    Título: ${titulo}
    Presença: ${resto.presenca ? 'Sim' : 'Não'}
    Comentário: ${resto.comentario}`)