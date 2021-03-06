import React, { useState, useEffect } from 'react';
import * as Papa from 'papaparse';

import { ScrollBar } from 'styles';
import { For } from 'modules/common';

import './CsvPreview.css';

export type CsvPreviewProps = {
    csvFile: File;
}

export const CsvPreview = ({ csvFile }: CsvPreviewProps) => {
    const [csvData, setCsvData] = useState<string[][]>([]);

    useEffect(() => {
        (async () => {
            const csvData = Papa.parse(await csvFile.text());
            if (csvData) {
                setCsvData(csvData.data.slice(0, 6) as string[][]);
            }
        })();
    }, [csvFile])

    if (csvData.length === 0) return null;

    return (
        <ScrollBar style={{height:"500px"}}>
            <table className="csv-table">
                <thead>
                <tr>
                    <th className="block padding" key="-1"/>
                    <For each={csvData[0]}
                         onEach={(h, i) => <th className="block" key={i}>{h}</th>}/>
                </tr>
                </thead>
                <tbody>
                <For each={csvData} onEach={(row, i) => (
                    <tr key={i}>
                        <td className="block padding" key="-1">{i}</td>
                        <For each={row} onEach={(val, j)=> (
                            <td key={j}>{val}</td>
                        )} />
                    </tr>
                )} />
                </tbody>
            </table>
        </ScrollBar>
    );
};