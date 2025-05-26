import React from "react";
import { Container, Row, Col, Form, Button } from "react-bootstrap";
import { FaEnvelope, FaLinkedin, FaGithub } from "react-icons/fa";
import Particle from "../components/Particle";
import chat from "../assets/chat.svg";

function Contact() {
  return (
    <Container fluid className="contact-section" id="contact">
      
      <Container>
        <h1 className="section-heading text-center mb-5">📬 Get In Touch</h1>
        <Row className="justify-content-center">
          <Col md={6}>
            <Form
              action="https://formspree.io/f/xldjaaad"
              method="POST"
            >
              <input type="hidden" name="_redirect" value="https://your-portfolio-url.com" />
              <Form.Group className="mb-3" controlId="formName">
                <Form.Label>Your Name</Form.Label>
                <Form.Control
                  type="text"
                  name="name"
                  placeholder="Enter your name"
                  required
                />
              </Form.Group>

              <Form.Group className="mb-3" controlId="formEmail">
                <Form.Label>Your Email</Form.Label>
                <Form.Control
                  type="email"
                  name="email"
                  placeholder="Enter your email"
                  required
                 
                />
              </Form.Group>

              <Form.Group className="mb-3" controlId="formMessage">
                <Form.Label>Your Message</Form.Label>
                <Form.Control
                  as="textarea"
                  name="message"
                  rows={4}
                  placeholder="Write your message..."
                  required
                />
              </Form.Group>

              <Button variant="primary" type="submit">
                Send Message
              </Button>
            </Form>
          </Col>
           <Col md={5} style={{ paddingBottom: 20 }}>
                        <img
                          src={chat}
                          alt="chat pic"
                          className="img-fluid"
                          style={{ maxHeight: "300px" }}
                        />
                      </Col>
        </Row>

        <Row className="justify-content-center mt-5">
          <Col md="auto" className="contact-icons">
            <a
              href="mailto:sameerb2831@gmail.com"
              target="_blank"
              rel="noopener noreferrer"
            >
              <FaEnvelope size={30} />
            </a>
          </Col>
          <Col md="auto" className="contact-icons">
            <a
              href="https://www.linkedin.com/in/sameer-balkawade"
              target="_blank"
              rel="noopener noreferrer"
            >
              <FaLinkedin size={30} />
            </a>
          </Col>
          <Col md="auto" className="contact-icons">
            <a
              href="https://github.com/sameer2831"
              target="_blank"
              rel="noopener noreferrer"
            >
              <FaGithub size={30} />
            </a>
          </Col>
        </Row>
      </Container>
    </Container>
  );
}

export default Contact;
