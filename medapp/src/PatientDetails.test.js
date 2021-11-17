import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";
import PatientPage from './PatientDetails.js';

let container = null;
beforeEach(() => {
  // setup a DOM element as a render target
  container = document.createElement("div");
  document.body.appendChild(container);
});

afterEach(() => {
  // cleanup on exiting
  unmountComponentAtNode(container);
  container.remove();
  container = null;
});

it("renders user data", async () => {
    const fakeUser = {
      name: "Mr. Instance Imre",
      socialSecurityNumber: "044-033-999",
      dateOfBirth: "2005-09-01T00:00:00",
      email: "",
      phonenumber: "",
      username: "Imre"
    };
    jest.spyOn(global, "fetch").mockImplementation(() =>
      Promise.resolve({
        json: () => Promise.resolve(fakeUser)
      })
    );
  
    // Use the asynchronous version of act to apply resolved promises
    await act(async () => {
      render(<PatientPage  />, container);
    });
    expect(container.querySelector("h5").textContent).toBe(fakeUser.name);
    expect(container.textContent).toContain(fakeUser.socialSecurityNumber);
    expect(container.textContent).toContain(fakeUser.dateOfBirth);
    expect(container.textContent).toContain(fakeUser.email);
    expect(container.textContent).toContain(fakeUser.phonenumber);
    expect(container.textContent).toContain(fakeUser.username);
    expect(container.querySelector("Button").textContent).toContain("Change my contact info");
    // remove the mock to ensure tests are completely isolated
    global.fetch.mockRestore();
  });