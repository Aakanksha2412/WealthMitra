import React from 'react';
import { VerticalTimelineElement } from 'react-vertical-timeline-component';
import './style.css'

const TimelineItem = ({ data }) => (
    <VerticalTimelineElement
        className="vertical-timeline-element--work"
        date={data.date}
        iconStyle={{ background: data.category.color, color: 'black' }}
        icon={<i className="fas fa-briefcase" />}
    >
        <h3 className="vertical-timeline-element-title" color='#000000'>{data.text
            }</h3>
        <h4 className="vertical-timeline-element-subtitle">
            <a href={data.link.url} target="_blank" rel="noopener noreferrer">{data.link.text}</a>
        </h4>
        <p>{data.category.tag}</p>
    </VerticalTimelineElement>
);

export default TimelineItem;
