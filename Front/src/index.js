import React from "react";
import ReactDOM from "react-dom";
import "./styles.scss";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

const rootElement = document.getElementById("root");

const App = () => {
    return <Router>
        <Switch>
            <Route exact path="/" component={() => <h1>It's live</h1>} />
        </Switch>
    </Router>
}
ReactDOM.render(<App />, rootElement);