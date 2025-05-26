import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import myImg from "../../assets/my-ghibli.png";
import Tilt from "react-parallax-tilt";
import {
  AiFillGithub,
  AiOutlineTwitter,
  AiFillInstagram,
} from "react-icons/ai";
import { FaLinkedinIn } from "react-icons/fa";

function Home2() {
    return (
      <Container fluid className="home-about-section" id="about">
        <Container>
          <Row>
            <Col md={8} className="home-about-description">
              <h1 style={{ fontSize: "2.6em" }}>
                LET ME <span className="purple"> INTRODUCE </span> MYSELF
              </h1>
              <p className="home-about-body">
              Hi, I'm a passionate Full-Stack Developer and current Master's student in Computer Science at Syracuse University.
                <br />
                <br /> I love crafting clean, scalable solutions and bringing ideas to life through code.
                <br />Whether it's building secure APIs or enhancing user experience, I thrive on solving real-world problems with modern tech.
                <br />
                With a strong foundation in  &nbsp;
                <i>
                  <b className="purple">software engineering, Agile methodologies, </b> and  <b className="purple">
                    system optimization,
                  </b>
                </i>
                <br />
                <br />
                I’m driven by innovation and a desire to build impactful, user-focused applications. 
              </p>
            </Col>
            <Col md={4} className="myAvtar">
              <Tilt>
                <img src={myImg} className="img-fluid" alt="avatar" />
              </Tilt>
            </Col>
          </Row>
          <Row>
            <Col md={12} className="home-about-social">
              <h1>FIND ME ON</h1>
              <p>
                Feel free to <span className="purple">connect </span>with me
              </p>
              <ul className="home-about-social-links">
                <li className="social-icons">
                  <a
                    href="https://github.com/sameer2831"
                    target="_blank"
                    rel="noreferrer"
                    className="icon-colour  home-social-icons"
                  >
                    <AiFillGithub />
                  </a>
                </li>
                
                <li className="social-icons">
                  <a
                    href="https://www.linkedin.com/in/sameer-balkawade"
                    target="_blank"
                    rel="noreferrer"
                    className="icon-colour  home-social-icons"
                  >
                    <FaLinkedinIn />
                  </a>
                </li>
                <li className="social-icons">
                  <a
                    href="https://www.instagram.com/_sameer_2831/"
                    target="_blank"
                    rel="noreferrer"
                    className="icon-colour home-social-icons"
                  >
                    <AiFillInstagram />
                  </a>
                </li>
              </ul>
            </Col>
          </Row>
        </Container>
      </Container>
    );
  }
  export default Home2;













