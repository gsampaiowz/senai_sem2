function Saudar(){
    event.preventDefault();

    let nome = document.getElementById('nome').value;
    
    let sobrenome = document.getElementById('sobrenome').value;
    
    alert(`Boa tarde ${nome} ${sobrenome}!`);
}
