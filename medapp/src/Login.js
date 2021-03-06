import React from 'react';
import { useState } from 'react';
import { useHistory } from "react-router-dom";
import{setWithExpiry} from './LocalStorageTTLUtils.js';
import { Button } from "react-bootstrap";
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
                if(res.error){
                    alert(res.error)
                    window.location.reload();
                }
                setWithExpiry(res);
                history.push("/");
                setTimeout(() => {
                    window.location.reload();    
                  }, 500);
            })
    }
    
        return (
            <div className="login-page">
                <div className="form">
                        <form className="login-form" onSubmit={handleSubmit}>
                        <label className="login-label">
                            Username:
                        </label>
                            <br />
                            <input
                                name="username"
                                type="textarea"
                                placeholder="eg. BelaLugosi11"
                                onChange={event => setUsername(event.target.value)} />
                        <br />
                        <label className="login-label">
                            Password:
                        </label>
                        <br />
                            <input
                                name="password"
                                type="password"
                                onChange={event => setPassword(event.target.value)} />
                        <br />
                        <Button variant="success" type="submit">Submit</Button>
                    </form>
                </div>
            </div>
        );
}


export default Login;