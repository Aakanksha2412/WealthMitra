import React from "react";
import { Card } from "react-bootstrap";

function PublicationCard({ title, journal, link }) {
  return (
    <Card className="project-card-view">
      <Card.Body>
        <Card.Title style={{ fontWeight: "bold" }}>{title}</Card.Title>
        <Card.Text style={{ fontSize: "0.9em", marginBottom: "10px" }}>
          <em>{journal}</em>
        </Card.Text>
        <a href={link} target="_blank" rel="noreferrer" className="btn btn-primary btn-sm">
          📄 Read Paper
        </a>
      </Card.Body>
    </Card>
  );
}

export default PublicationCard;
