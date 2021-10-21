import React,{Component} from 'react';
import {Table} from 'react-bootstrap';

export class Home extends Component{

    constructor(props){
        super(props);
        this.state={coro:[], corohun:[]}
    }

    refreshList(){
        fetch("https://coronavirus.m.pipedream.net/",
               { method: 'GET',
               headers: {
               'Accept': 'application/json',
               'Content-Type': 'application/json'
               }})
           .then(response=>response.json())
           .then(data=>{
           this.setState({coro:data.summaryStats.global, corohun:data.rawData.find(item => item.Country_Region === "Hungary")});
       });
   }

   componentDidMount(){
       this.refreshList();
   }

    render(){
        return(
            <div className="mt-5 justify-content-center">
                <h2>Welcome to SuperduperMedapp Site!</h2>
                <h4>Current Coronavirus Stats</h4>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Confirmed</th>
                            <th>Deaths</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{this.state.coro.confirmed}</td>
                            <td>{this.state.coro.deaths}</td>
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
                            <td>{this.state.corohun.Confirmed}</td>
                            <td>{this.state.corohun.Deaths}</td>
                        </tr>
                    </tbody>
                </Table>
                <h4>Placeholder articles</h4>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras pulvinar urna nisi, non interdum ipsum pulvinar ullamcorper. Suspendisse eros lorem, mollis vel pellentesque molestie, dictum dictum lorem. Duis ipsum dui, accumsan at eleifend quis, sodales dignissim eros. Nunc at sollicitudin leo, vel sagittis ligula. Nullam massa velit, mattis eget dolor nec, posuere molestie ante. Maecenas in ipsum sit amet justo ultrices placerat dignissim ac nibh. Nunc a felis lacus.</p>
            </div>
        )
    }
}