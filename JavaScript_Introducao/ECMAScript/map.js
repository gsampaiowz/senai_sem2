//foreach
//map
//filter
//reduce

const numeros = [1,2,5,10,300];

const soma = numeros.reduce((vlInicial, n) => {
    return vlInicial + n
}, 3)

console.log(soma)

// numeros.map();

// const maior10 = numeros.filter((e) => {
//     return e > 10;
// })

const comentarios = [
    {comentario: "bla bla bla", exibe: true},
    {comentario: "p0rr# c4r4lh0", exibe: false},
    {comentario: "ótimo evento!", exibe: true},
]

const comentariosOk = comentarios.filter((e) => {
    return e.exibe;
})

const exibe = comentariosOk.forEach((c,i) => {
    console.log(`Comentário ${i+1}: ${c.comentario}`)
})