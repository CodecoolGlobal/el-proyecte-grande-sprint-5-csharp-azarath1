import './App.css';
import {Home} from './Home';
import {Signup} from './Signup';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { Medicine } from './Medicine';
  
function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       MedApp
     </h3>

     <Navigation/>

     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/signup' component={Signup}/>
       <Route path='/medicines' component={Medicine}/>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
