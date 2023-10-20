const camisaNike = {
    descricao: 'Camisa Nike Corinthians I',
    preco: 229.9,
    marca: 'Nike',
    tamanho: 'G',
    cor: 'Preta',
    promocao: true, 
}

const { descricao, preco, promocao } = camisaNike;

console.log(`
    Descrição: ${descricao}
    Preço: ${preco}
    Promoção: ${promocao}`)