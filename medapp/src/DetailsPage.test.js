import React from "react";
import { render, unmountComponentAtNode } from "react-dom";
import { act } from "react-dom/test-utils";
import PersonalDetails from "./DetailsPage.js";

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

it("renders loading when not find current user", async () => {
    const loading = {
      textelement: "Loading..."
    };
    jest.spyOn(global, "fetch").mockImplementation(() =>
      Promise.resolve({
        json: () => Promise.resolve(loading)
      })
    );
  
    // Use the asynchronous version of act to apply resolved promises
    await act(async () => {
      render(<PersonalDetails  />, container);
    });
    expect(container.textContent).toContain(loading.textelement);
    // remove the mock to ensure tests are completely isolated
    global.fetch.mockRestore();
  });