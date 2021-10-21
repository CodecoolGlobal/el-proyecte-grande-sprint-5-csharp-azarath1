import React, { Component } from 'react';

export class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            userName: "Name",
            password: "Password"
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        if (event.target.name === "username") {
            this.setState({ userName: event.target.value })
        }
        else if (event.target.name === "password") {
            this.setState({ password: event.target.value })
        }
    }

    async handleSubmit(event) {
        event.preventDefault();
        await fetch(process.env.REACT_APP_BASE_URL_PATIENT+'login', {
            method: 'post',
            headers : { 
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "Username": this.state.userName.toString(),
                "HashPassword": this.state.password.toString()
            }),
        })
            .then(res => res.json())
            .then((res) => {
                console.log(res);
            })
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Username:
                    <input
                        name="username"
                        type="textarea"
                        value={this.state.userName}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <label>
                    Password:
                    <input
                        name="password"
                        type="textarea"
                        value={this.state.password}
                        onChange={this.handleInputChange} />
                </label>
                <br />
                <input type="submit" value="Submit" />
            </form>
        );
    }
}