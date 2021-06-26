import { useEffect, useState, forwardRef } from 'react';
import MaterialTable from 'material-table'
import './App.css'
import t2sLogo from './logo-t2s.png'
import AddBox from '@material-ui/icons/AddBox';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';

const tableIcons = {
    Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
    Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
    DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
    Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
    Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
    ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
    ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
  };


const API_URL = "http://localhost:5000/api"

const requestAPI = async (path) => {
    const endpoint = `${API_URL}/${path}`
    const request = await fetch(endpoint)
    const response = await request.json()
    return response
}

function App() {
  const [conteiner, setConteinerResponse] = useState([])
  const [clientes, setClientesResponse] = useState([])
  const [movimentacoes, setMovimentacoesResponse] = useState([])
  const [tipoMovimentacao, setTipoMovimentacao] = useState([])
  const [relatorio, setRelatorio] = useState([])
  const [clienteId, setClientId] = useState(null)

  const requestConteiner = async () => {
      const data = await requestAPI("conteiners")
      setConteinerResponse(data)
  }

  const requestClientes = async () => {
    const data = await requestAPI("clientes")
    setClientesResponse(data)
  }

  const requestMovimentacao = async () => {
    const data = await requestAPI("movimentacaos")
    setMovimentacoesResponse(data)
  }
 
    const requestTipoMovimentacao = async () => {
        const data = await requestAPI("tipomovimentacaos")
        setTipoMovimentacao(data)
    }

    const requestRelatorio = async () => {
        const data = await requestAPI(`movimentacaos/clientes/${clienteId}`)
        setRelatorio(data)
    }

    useEffect(() => {
        requestConteiner()
        requestClientes()
        requestMovimentacao()
        requestTipoMovimentacao()
    }, [])

  return (
    <div className="App">
        <header>
            <img src={t2sLogo} width={130} alt={"Logo T2S"} />
        </header>
        <div className="Container">
      <h1>Conteiner</h1>
      <MaterialTable
        columns={[
          {title: "ID", field: "idconteiner"},
          {title: "Numero Container", field: "numeroConteiner"},
          {title: "Status", field: "statusConteiner"},
          {title: "Categoria", field: "categoria"},
          {title: "ID Cliente", field: "idCliente"},
          {title: "Tipo", field: "tipo"}
        ]}
        data={conteiner}
        title={""}
        icons={tableIcons}
      />

      <h1>Clientes</h1>
      <MaterialTable
        columns={[
          {title: "ID", field: "idcliente"},
          {title: "Email", field: "email"},
        ]}
        data={clientes}
        title={""}
        icons={tableIcons}
      />

      <h1>Movimentações</h1>
      <MaterialTable
        columns={[
          {title: "ID", field: "idmovimentacao"},
          {title: "Hora Inicio", field: "dataHoraInicio"},
          {title: "Hora Fim", field: "dataHoraFim"},
          {title: "ID Cliente", field: "idCliente"},
          {title: "ID Movimentacao", field: "idmovimentacao"}
        ]}
        data={movimentacoes}
        title={""}
        icons={tableIcons}
      />

      <h1>Tipos de Movimentação</h1>
      <MaterialTable
        columns={[
          {title: "ID", field: "idtipoMovimentacao"},
          {title: "Tipo", field: "tipo"}
        ]}
        data={tipoMovimentacao}
        title={""}
        icons={tableIcons}
      />

      <h1>Relatório</h1>
      <input 
        placeholder="Buscar relatório por cliente" 
        onChange={(event) => setClientId(event.target.value)}
        />
      <button  onClick={() => requestRelatorio()}>Buscar</button>
        <MaterialTable
          columns={[
            {title: "ID", field: "idmovimentacao"},
            {title: "Hora Inicio", field: "dataHoraInicio"},
            {title: "Hora Fim", field: "dataHoraFim"},
            {title: "ID Cliente", field: "idCliente"},
            {title: "ID Movimentacao", field: "idmovimentacao"}
          ]}
          data={relatorio}
          icons={tableIcons}
        />
        </div>
    </div>
  );
}

export default App;
