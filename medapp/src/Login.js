// import { BehaviorSubject } from 'rxjs';
import React from 'react';
import { useState } from 'react';
import { useHistory } from "react-router-dom";
import{setWithExpiry} from './LocalStorageTTLUtils.js';
// const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));

function Login() {
    const history = useHistory();
    const [userName, setUsername] = useState("Name");
    const [password, setPassword] = useState("Password");

    async function handleSubmit(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL + 'login', {
            method: 'post',
            mode:'cors',
            credentials: 'include',
            headers : { 
                'Access-Control-Allow-Credentials':'true',
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "Username": userName,
                "Password": password
            }),
        })
            .then(res => res.json())
            .then((res) => {
                setWithExpiry(res);
                history.push("/");
                setTimeout(() => {
                    window.location.reload();    
                  }, 1000);
            })
    }
    
        return (
            <form onSubmit={handleSubmit}>
                <label>
                    Username:
                </label>
                    <br />
                    <input
                        name="username"
                        type="textarea"
                        placeholder="eg. BelaLugosi11"
                        onChange={event => setUsername(event.target.value)} />
                <br />
                <label>
                    Password:
                </label>
                <br />
                    <input
                        name="password"
                        type="password"
                        onChange={event => setPassword(event.target.value)} />
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
}


export default Login;