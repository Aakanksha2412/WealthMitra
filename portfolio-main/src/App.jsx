import { HashRouter  as Router, Routes, Route } from "react-router-dom";
import React, { useState, useEffect } from "react";
import Preloader from "./components/Pre";
import Footer from "./components/Footer";
import Home from './pages/Home/Home';
import About from './pages/About/About';
import Projects from './pages/Projects/Projects';
import Contact from './pages/Contact';
import ScrollToTop from "./components/ScrollToTop";
import Navbar from './components/Navbar';
import "./App.css";
import "./style.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Navigate } from "react-router-dom";


function App() {
  const [load, upadateLoad] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => {
      upadateLoad(false);
    }, 1200);

    return () => clearTimeout(timer);
  }, []);
  return (
    <Router>
      <Preloader load={load} />
      <div className="App" id={load ? "no-scroll" : "scroll"}>
        <Navbar />
        <ScrollToTop />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/projects" element={<Projects />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="*" element={<Navigate to="/"/>} />
      </Routes>
      <Footer/>
      </div>
    </Router>
  );
}
export default App;
