import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import ProjectCard from "./ProjectCards";
import Particle from "../../components/Particle";
import shuttle from "../../assets/shuttle.jpeg";
import reddit from "../../assets/reddit.jpg";
import dcgan from "../../assets/dcgan.png";
import fest from "../../assets/fest.jpeg";
import portfolio from "../../assets/portfolio.jpeg"
import PublicationCard from "./PublicationCard";

function Projects() {
  return (
    <Container fluid className="project-section">
      <Particle />
      <Container>
        <h1 className="project-heading">
          My Technical <strong className="purple">Projects</strong>
        </h1>
        <p style={{ color: "white" }}>
          Here are a few technical projects I've worked on recently.
        </p>
        <Row style={{ justifyContent: "center", paddingBottom: "10px" }}>

          <Col md={4} className="project-card">
            <ProjectCard
              imgPath={shuttle}
              isBlog={false}
              title="Shuttle Ride Management System"
              description="MERN stack app with JWT-based auth and RBAC. Optimized MongoDB schema with factory/repository patterns, reducing query time by 60%. Boosted UI responsiveness by 40% using WebSockets and REST APIs."
              ghLink="#"
            />
          </Col>

          <Col md={4} className="project-card">
            <ProjectCard
              imgPath={reddit}
              isBlog={false}
              title="Reddit WallStreetBets Sentiment Analysis"
              description="Performed sentiment analysis using NLP tools like Vader, GloVe, LSTM on WallStreetBets posts. Visualized results using Seaborn & Matplotlib, enhancing sentiment classification accuracy by 15%."
              ghLink="https://github.com/sameer2831/Reddit-WallStreetBets-Sentiment-Analysis"
            />
          </Col>

          <Col md={4} className="project-card">
            <ProjectCard
              imgPath={dcgan}
              isBlog={false}
              title="Skin Lesions Data Augmentation using DCGAN"
              description="Developed a DCGAN to synthetically generate skin lesion images, increasing dataset size by 72% and CNN model accuracy by 9%. Supported research in dermatology and medical imaging."
              ghLink="#"
            />
          </Col>

          <Col md={4} className="project-card">
            <ProjectCard
              imgPath={fest}
              isBlog={false}
              title="Android App for College Fest"
              description="Built an Android app for online fest registration using Firebase and REST APIs. Integrated Google Maps and animation libraries, boosting engagement by 20%."
              ghLink="#"
            />
          </Col>

          <Col md={4} className="project-card">
            <ProjectCard
              imgPath={portfolio}
              isBlog={false}
              title="Personal Developer Portfolio"
              description="My personal portfolio built with React, Tailwind CSS, and GitHub Pages. Includes responsive design, routing, project showcase, and theme animations."
              ghLink="https://github.com/sameer2831/portfolio"
              demoLink="https://sameer2831.github.io/portfolio"
            />
          </Col>

        </Row>
        <Container fluid className="publication-section">
        <Container>
          <h1 className="project-heading">
            Research <strong className="purple">Publications</strong>
          </h1>
          <Row style={{ justifyContent: "center", paddingTop: "10px" }}>
            <Col md={6} className="project-card">
              <PublicationCard
                title="Skin Lesion Image Augmentation using DCGAN"
                journal="IRJET, Volume 8, Issue 7, July 2021"
                link="https://www.irjet.net/archives/V8/i7/IRJET-V8I7142.pdf"
              />
            </Col>

            <Col md={6} className="project-card">
              <PublicationCard
                title="Data Augmentation on Skin Lesion Image Data Using GAN for Increased CNN Performance"
                journal="IRJET, Volume 8, Issue 5, May 2021"
                link="https://www.irjet.net/archives/V8/i5/IRJET-V8I5328.pdf"
              />
            </Col>
          </Row>

        </Container>
      </Container>

      </Container>
    </Container>
  );
}

export default Projects;
