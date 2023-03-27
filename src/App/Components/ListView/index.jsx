import './ListView.css'
import "react-tabulator/lib/styles.css";
import "react-tabulator/css/bootstrap/tabulator_bootstrap.min.css";
import React, { Fragment, useState, useRef } from 'react'
import { useSetTitle } from '../../Utils'
import { Header, Sidebar } from '../Partials'
import { Link, useNavigate } from 'react-router-dom'
import Swall from 'sweetalert2'
import { ReactTabulator, reactFormatter } from "react-tabulator";
import data from './data'
import { FaTrashAlt, FaEdit, FaListAlt, FaPlusCircle } from 'react-icons/fa'
// import { useGetEmployeListQuery } from '../../Features/api/employeApiSlice'

function SimpleOptions(props) {
  const rowData = props.cell._cell.row.data;

  return (
    <div className='btnOptions'>
      <button className='green' onClick={() => props.handlers.handleDetail(rowData.id) }><FaListAlt /></button>
      <button className='orange' onClick={() => props.handlers.handleEdit(rowData.id) }><FaEdit /></button>
      <button className='red' onClick={() => props.handlers.handleDelete(rowData.id) }><FaTrashAlt /></button>
    </div>
  )
}

const ListView = ({ title }) => {

  const searchRef = useRef()
  useSetTitle('Employee List')
  
  const [TableData, setTableData] = useState(data)
  // const { employes , isLoading, isSuccess, error } = useGetEmployeListQuery()

  const handleSearch = (e) => {
    e.preventDefault()
    const searchRefValue = searchRef.current.value 
    if(searchRefValue !== ''){
      const filteredData = data.filter( data => {
        return data.firstname.toLowerCase() === searchRefValue.toLowerCase() ||
              data.lastname.toLowerCase() === searchRefValue.toLowerCase() ||
              data.email.toLowerCase() === searchRefValue.toLowerCase() ||
              data.post.toLowerCase() === searchRefValue.toLowerCase() ||
              data.takeon.toLowerCase() === searchRefValue.toLowerCase() ||
              data.salary.toLowerCase() === searchRefValue.toLowerCase()
      })
      filteredData ? setTableData(filteredData) : setTableData([])
    }else{
      setTableData(data)
    }
  }
  
  const navigate = useNavigate()

  const handleEdit = (id) => {
    navigate(`/employee/edit/${id}`)
  }

  const handleDetail = (id) => {
    navigate(`/employee/detail/${id}`)
  }

  const handleDelete = (id) => {
    Swall.fire('Are you sure to delete it')
  }

  const handlers = {
    handleEdit,
    handleDetail,
    handleDelete
  }

  const columms = [
    { title: 'firstname', field: 'firstname' },
    { title: 'lastname', field: 'lastname' },
    { title: 'email', field: 'email' },
    { title: 'salary', field: 'salary' },
    { title: 'take On', field: 'takeon' },
    { title: 'options', field: 'id', formatter: reactFormatter(<SimpleOptions handlers={handlers} />) }
  ]

  return (
    <Fragment>
      <Sidebar active={'employee'} />
      <section className='baseview'>
        <Header />
        <div className="contentview">
          <div className='table-container'>
            <div className="table-title-container">
              <h4 className='table-title'>Liste des Employees</h4>
            </div>
            <div className="table-header">
              <Link to={'/employee/new'}>
                <button className="addnewEmploye"><FaPlusCircle /></button>
              </Link>
              <input type="search" name="search" placeholder='recherche...' onChange={ handleSearch } className='search' ref={searchRef} />
            </div>
            <ReactTabulator
              data={TableData}
              columns={columms}
              options={
                {
                  pagination: 'local',
                  paginationSize: 10,
                  paginationSizeSelector: [25, 50, 100]
                }
              }
            />
          </div>
        </div>
      </section>
    </Fragment>
  )
}

export default ListView