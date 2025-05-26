import React from "react";
import { Col, Row, Card } from "react-bootstrap";
import { 
  DiJavascript1, DiReact, DiNodejs, DiMongodb, DiPython, DiGit, DiJava,
  DiVisualstudio, DiHtml5, DiCss3, DiMysql, DiPostgresql
} from "react-icons/di";
import { TbBrandCSharp } from "react-icons/tb";
import { VscAzureDevops } from "react-icons/vsc";
import {
  SiTypescript, SiCplusplus, SiJson, SiFirebase, SiNextdotjs,
  SiDotnet, SiAngular, SiOracle, SiDocker, SiJenkins, SiGithub, SiGitlab,
  SiPostman, SiAmazonaws, SiSqlite, SiYaml, SiElastic, SiRabbitmq
} from "react-icons/si";
import { FaAws } from "react-icons/fa";

function Techstack() {
  return (
    <Row style={{ justifyContent: "center", paddingBottom: "50px" }}>
      {/* Languages */}
      <Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>Languages</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><DiJavascript1 /></Col>
              <Col xs={4} className="tech-icons"><SiTypescript /></Col>
              <Col xs={4} className="tech-icons"><DiJava /></Col>
              <Col xs={4} className="tech-icons"><DiPython /></Col>
              <Col xs={4} className="tech-icons"><TbBrandCSharp /></Col>
              <Col xs={4} className="tech-icons"><SiCplusplus /></Col>
              <Col xs={4} className="tech-icons"><DiHtml5 /></Col>
              <Col xs={4} className="tech-icons"><DiCss3 /></Col>
              <Col xs={4} className="tech-icons"><SiJson /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>

      {/* Frameworks */}
      <Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>Frameworks</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><DiReact /></Col>
              <Col xs={4} className="tech-icons"><DiNodejs /></Col>
              <Col xs={4} className="tech-icons"><SiNextdotjs /></Col>
              <Col xs={4} className="tech-icons"><SiDotnet /></Col>
              <Col xs={4} className="tech-icons"><SiAngular /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>
    
      {/* Databases */}
      <Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>Databases</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><DiMongodb /></Col>
              <Col xs={4} className="tech-icons"><DiPostgresql /></Col>
              <Col xs={4} className="tech-icons"><DiMysql /></Col>
              <Col xs={4} className="tech-icons"><SiFirebase /></Col>
              <Col xs={4} className="tech-icons"><SiOracle /></Col>
              <Col xs={4} className="tech-icons"><SiSqlite /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>

      {/* DevOps & Tools */}
      <Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>DevOps & Tools</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><FaAws /></Col>
              <Col xs={4} className="tech-icons"><VscAzureDevops /></Col>
              <Col xs={4} className="tech-icons"><SiDocker /></Col>
              <Col xs={4} className="tech-icons"><SiJenkins /></Col>
              <Col xs={4} className="tech-icons"><SiGithub /></Col>
              <Col xs={4} className="tech-icons"><SiGitlab /></Col>
              <Col xs={4} className="tech-icons"><SiPostman /></Col>
              <Col xs={4} className="tech-icons"><DiVisualstudio /></Col>
              <Col xs={4} className="tech-icons"><SiYaml /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>

      {/* Web Tech */}
      <Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>Web Tech</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><SiRabbitmq /></Col>
              <Col xs={4} className="tech-icons"><SiElastic /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>

      {/* Version Control */}
      {/*<Col xs={12} md={6} lg={4} className="mb-4">
        <Card>
          <Card.Body>
            <Card.Title>Version Control</Card.Title>
            <Row>
              <Col xs={4} className="tech-icons"><DiGit /></Col>
            </Row>
          </Card.Body>
        </Card>
      </Col>*/}
    </Row>
  );
}

export default Techstack;
