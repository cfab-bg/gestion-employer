import './DetailView.css'
import React, { Fragment } from 'react'
import { Header, Sidebar } from '../Partials'
import { useSetTitle } from '../../Utils'
import { FaCheckSquare, FaSquareFull } from 'react-icons/fa'
import { useGetEmployeDetailQuery } from '../../Features/api/employeApiSlice'
import { useParams } from 'react-router-dom'

const DetailView = ({ title }) => {

  useSetTitle(title)

  const { id } = useParams()

  const { employee, isLoading, isError } = useGetEmployeDetailQuery(id)
  console.log(employee)
  // const avatanges = employee.avantages ? employee.avantages.map((avantage) => {
  //   return(
  //     <div className="av-item" key={avantage.AvantageId}>
  //     <FaSquareFull className='unchecked' />
  //     <div className="data-value">{ avantage.Nom }</div>
  //   </div>
  //   )
  // }) : <div>Pas d'avantage</div>

  return (
    <Fragment>
      <Sidebar active={'employee'} />
      <section className='baseview'>
        <Header />
        <div className="contentview">
          <div className='table-container'>
            <div className="table-title-container">
              <h4 className='table-title'>Employee detail</h4>
            </div>
            <div className="data-container">
              <div className="panel-left">
                <div className="data-row">
                  <div className="data-label">First name </div>
                  {/* <div className="data-value">{ employee.nom ? employee.nom : 'Non defini'}</div> */}
                </div>
                <div className="data-row">
                  <div className="data-label">Email</div>
                  {/* <div className="data-value">{employee.email ? employee.email : 'Non defini'}</div> */}
                </div>
                <div className="data-row">
                  <div className="data-label">Salaire de base</div>
                  {/* <div className="data-value">{employee.salaire ? employee.salaire : 'Non defini'}</div> */}
                </div>
              </div>
              <div className="panel-right">
                <div className="data-row">
                  <div className="data-label">Last name</div>
                  {/* <div className="data-value">{employee.prenom ? employee.prenom : 'Non defini'}</div> */}
                </div>
                <div className="data-row">
                  <div className="data-label">Post</div>
                  {/* <div className="data-value">{employee.post ? employee.post : 'Non defini'}</div> */}
                </div>
                <div className="data-row">
                  <div className="data-label">Date d'embauche</div>
                  {/* <div className="data-value">{employee.date ? employee.date : 'Non defini'}</div> */}
                </div>
              </div>
            </div>
            <div className="data-row-max">
              <div className="data-row">
                <div className="data-label">Avantages</div>
                <div className="avantages">
                  {/* { avatanges } */}
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </Fragment>
  )
}

export default DetailView