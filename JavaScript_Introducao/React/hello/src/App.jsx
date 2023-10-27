import "./App.css";
import CardEvento from "./components/CardEvento/CardEvento";
import Titulo from "./components/Titulo/Titulo";

function App() {
  return (
    <div className="App">
      <h1>My App</h1>
      <Titulo texto="React"/>
      <Titulo texto="Next"/>
      <CardEvento tituloTexto="React" descricaoTexto="O react é uma biblioteca do javascript que nos ajuda a criar interfaces UI de forma mais performática." botaoTexto='Conectar'/>
      <CardEvento disabled tituloTexto="React" descricaoTexto="O react é uma biblioteca do javascript que nos ajuda a criar interfaces UI de forma mais performática." botaoTexto='Conectar'/>
    </div>
  );
}

export default App;
