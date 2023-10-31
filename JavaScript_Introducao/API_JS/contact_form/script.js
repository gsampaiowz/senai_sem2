const urlLocal = "http://localhost:3000/contatos";

const ExibirDados = (dados) => {
  document.getElementById("rua").value = dados.logradouro;
  document.getElementById("complemento").value = dados.complemento;
  document.getElementById("bairro").value = dados.bairro;
  document.getElementById("cidade").value = dados.localidade;
  document.getElementById("UF").value = dados.uf;
};

const LimparDados = (dados) => {
  document.getElementById("rua").value = "";
  document.getElementById("complemento").value = "";
  document.getElementById("bairro").value = "";
  document.getElementById("cidade").value = "";
  document.getElementById("UF").value = "";
};

const ChamarApi = async (e) => {
  e.preventDefault();

  const cep = document.getElementById("cep").value;
  const url = `https://viacep.com.br/ws/${cep}/json/`;
  console.log(`URL: ${url}`);
  console.log(`CEP: ${cep}`);

  try {
    const promise = await fetch(url);
    const dados = await promise.json();
    if (dados.erro) return alert("CEP inexiste!");
    ExibirDados(dados);
  } catch (error) {
    console.log(`Erro ao chamar a API: ${error}`);
    LimparDados();
    alert("CEP não encontrado!");
  }
};

const Cadastrar = async (e) => {
  e.preventDefault();

  const rua = document.getElementById("rua").value;
  const complemento = document.getElementById("complemento").value;
  const bairro = document.getElementById("bairro").value;
  const cidade = document.getElementById("cidade").value;
  const UF = document.getElementById("UF").value;
  const cep = document.getElementById("cep").value;
  const nome = document.getElementById("nome").value;
  const sobrenome = document.getElementById("sobrenome").value;
  const email = document.getElementById("email").value;
  const telefone = document.getElementById("telefone").value;
  const pais = document.getElementById("pais").value;
  const ddd = document.getElementById("ddd").value;
  const anotacoes = document.getElementById("anotacoes").value;

  const nomeCompleto = `${nome.trim()} ${sobrenome.trim()}`;
  const telefoneCompleto = `${pais.trim()} (${ddd.trim()}) ${telefone.trim()}`;

  const objDados = {
    cep,
    rua,
    complemento,
    bairro,
    cidade,
    UF,
    nomeCompleto,
    email,
    telefoneCompleto,
    anotacoes,
  };

  try {
    const promise = await fetch(urlLocal, {
      body: JSON.stringify(objDados),
      headers: { "Content-Type": "application/json" },
      method: "POST",
    });
    const dados = await promise.json();
    console.log(dados);
  } catch {
    console.error(`Erro ao cadastrar: ${error}`);
  }
};
