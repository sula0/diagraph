import React from 'react';

import { Event } from 'types';
import { Box, For, LocalTime, ScrollBar } from 'modules/common';

import 'App.css';
import './RecentEvents.css';

export interface RecentEventsProps {
    events: Event[];
    onEdit?: (e: Event) => void
}

export const RecentEvents: React.FC<RecentEventsProps> = ({ events, onEdit }) => {
    return (
        <Box>
            <h3>Recent events:</h3>
            <table className="table">
                <thead>
                <tr>
                    {events.length > 0 && (
                        <>
                            <td></td>
                            <td></td>
                            <td></td>
                        </>
                    )}
                </tr>
                </thead>
                <tbody>
                <For each={events} onEach={e => (
                    <tr key={e.id.toString()}>
                        <td className="box">
                            <LocalTime date={e.occurredAtUtc} />
                        </td>
                        <td className="block" style={{whiteSpace:"pre-line"}}>
                            <ScrollBar heightPx={125} widthPx={300}>
                                {e.text}
                            </ScrollBar>
                        </td>
                        <td>
                            {onEdit && (
                                <button className="button blue"
                                        onClick={() => onEdit(e)}>
                                    Edit
                                </button>
                            )}
                        </td>
                    </tr>
                )}
                />
                </tbody>
            </table>
        </Box>
    );
}