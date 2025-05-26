import React from 'react';
import { VerticalTimeline, VerticalTimelineElement } from 'react-vertical-timeline-component';
import 'react-vertical-timeline-component/style.min.css'; // Import the CSS for the timeline component
import './style.css';

import timelineData from './TimeLineData';

const Timeline = () => (
    <VerticalTimeline>
        {timelineData.map((data, idx) => (
            <VerticalTimelineElement
                key={idx}
                className="vertical-timeline-element--work"
                date={data.date}
                iconStyle={{ background: data.category.color, color: '#fff' }} // Add background color and text color
                icon={<i className="fas fa-briefcase" />} // You can change the icon to whatever you prefer
            >
                <h3 className="vertical-timeline-element-title">{data.text}</h3>
                <h4 className="vertical-timeline-element-subtitle">
                    <a href={data.link.url} target="_blank" rel="noopener noreferrer">{data.link.text}</a>
                </h4>
                <p className='vertical-timeline-element-tag'>{data.category.tag}</p>
            </VerticalTimelineElement>
        ))}
    </VerticalTimeline>
);

export default Timeline;
