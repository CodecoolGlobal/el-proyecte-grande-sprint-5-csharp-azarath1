import { useState, useEffect, } from 'react';
import {Table} from 'react-bootstrap';

function Home() {

    const [coronaDetails, setDetails] = useState(null);
    const [coronaHunDetails, setHunDetails] = useState(null);
    useEffect(() => {
        let isActive = true;
        getData();
    
        async function getData() {
    
          const response = await fetch("https://coronavirus.m.pipedream.net/",
          { 
            method: 'GET',
            headers: { 'Accept': 'application/json', 
                       'Content-Type': 'application/json' }
            });
          const data = await response.json();
          const coro = data.summaryStats.global;
          const coroHun = data.rawData.find(item => item.Country_Region === "Hungary");
          if (isActive){
            setDetails(coro);
            setHunDetails(coroHun);
          }
          return () => {
            isActive = false;
          };
        }
      }, []);
        if(coronaDetails && coronaHunDetails){
            return (
                    <div className="justify-content-center">
                        <h2 className="text-danger">Welcome to SuperduperMedapp!</h2>
                        <div className="card text-white bg-secondary mb-3">
                            <div className="card-header"><h4>Current Coronavirus Statistics</h4></div>
                                <div className="card-body">
                                    <Table className="mt-4" striped bordered hover size="sm">
                                        <thead>
                                            <tr>
                                                <th>Confirmed Globally</th>
                                                <th>Deaths</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td className="text-danger">{coronaDetails.confirmed}</td>
                                                <td>{coronaDetails.deaths}</td>
                                            </tr>
                                        </tbody>
                                        <thead>
                                            <tr>
                                                <th>Confirmed in Hungary</th>
                                                <th>Deaths in Hungary</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td className="text-danger">{coronaHunDetails.Confirmed}</td>
                                                <td>{coronaHunDetails.Deaths}</td>
                                            </tr>
                                        </tbody>
                                    </Table>
                                </div>
                        </div>
                        
                        <h4>Placeholder articles</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras pulvinar urna nisi, non interdum ipsum pulvinar ullamcorper. Suspendisse eros lorem, mollis vel pellentesque molestie, dictum dictum lorem. Duis ipsum dui, accumsan at eleifend quis, sodales dignissim eros. Nunc at sollicitudin leo, vel sagittis ligula. Nullam massa velit, mattis eget dolor nec, posuere molestie ante. Maecenas in ipsum sit amet justo ultrices placerat dignissim ac nibh. Nunc a felis lacus.</p>
                    </div>   
            )
        }
        else{
          return (
            <div className="justify-content-center">
            <h2 className="text-danger">Welcome to SuperduperMedapp!</h2>
            <div className="card text-white bg-secondary mb-3">
                <div className="card-header"><h4>Current Coronavirus Statistics</h4></div>
                <div className="d-flex justify-content-center">
                    <h1>
                        <div className="spinner-border text-danger" role="status">
                        <span className="visually-hidden">Loading...</span>
                        </div>
                    </h1>
                </div>
            </div>
            
            <h4>Placeholder articles</h4>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras pulvinar urna nisi, non interdum ipsum pulvinar ullamcorper. Suspendisse eros lorem, mollis vel pellentesque molestie, dictum dictum lorem. Duis ipsum dui, accumsan at eleifend quis, sodales dignissim eros. Nunc at sollicitudin leo, vel sagittis ligula. Nullam massa velit, mattis eget dolor nec, posuere molestie ante. Maecenas in ipsum sit amet justo ultrices placerat dignissim ac nibh. Nunc a felis lacus.</p>
            </div>   
          )
        }
      }

export default Home;