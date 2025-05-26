import React from "react";
import Card from "react-bootstrap/Card";
import { ImPointRight } from "react-icons/im";

function AboutCard() {
  return (
    <Card className="quote-card-view">
      <Card.Body>
        <blockquote className="blockquote mb-0">
          <p style={{ textAlign: "justify" }}>
            Hi Everyone, I am <span className="purple">Sameer Ashok Balkawade </span>
            
            <br />
            a passionate Full-Stack Developer and Computer Science graduate student at Syracuse University.
            <br />
            With hands-on experience in both enterprise and startup environments, I specialize in building scalable web and mobile applications using modern technologies like React, Node.js, .NET, and cloud platforms like AWS and Azure
            <br />
            <br />
            Whether it’s designing secure APIs, optimizing database performance, or leading a dev team, I thrive on solving real-world problems with clean, efficient code.
            <br />
            I'm always exploring new tech, and I love creating impactful solutions that blend functionality with great user experience.
            <br />
          </p>
          

          <p style={{ color: "rgb(155 126 172)" }}>
            "Great developers don’t just write code, they solve problems."{" "}
          </p>
          <footer className="blockquote-footer">Anonymus</footer>
        </blockquote>
      </Card.Body>
    </Card>
  );
}

export default AboutCard;