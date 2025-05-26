import React from 'react';
import { Container, Row, Col } from "react-bootstrap";
import Particle from "../../components/Particle";

import Techstack from "./TechStack";
import Aboutcard from "./AboutCard";
import laptopImg from "../../assets/avatar.jpg";
import Timeline from "./TimelineComponent";
import './style.css';


function About() {
  return (
    <Container fluid className="about-section">
      <Particle />
      <Container>
        <Row style={{ justifyContent: "center", padding: "10px" }}>
          <Col
            md={7}
            style={{
              justifyContent: "center",
              paddingTop: "30px",
              paddingBottom: "50px",
            }}
          >
            <h1 style={{ fontSize: "2.1em", paddingBottom: "20px" }}>
            💡 Know Who <strong className="purple">I'M</strong>
            </h1>
            <Aboutcard />
          </Col>
          <Col
            md={5}
            style={{ paddingTop: "120px", paddingBottom: "50px" }}
            className="about-img"
          >
            <img src={laptopImg} alt="about" className="img-fluid" />
          </Col>
        </Row>
        
        {/* Add the Timeline component here */}
        <h1 className="project-heading">
          Education & <strong className="purple">Work Experience</strong>
        </h1>
        <br />
        <Timeline />
        <br />
        <br />
        <h1 className="project-heading">
          Professional <strong className="purple">Skillset </strong>
        </h1>

        <Techstack />

      </Container>
    </Container>
  );
}

export default About;

