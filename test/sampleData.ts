export const sampleData = [
    {
        'testCase': 'side side side',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 }
        ],
        'output': [
            { 'id': 'angleA', 'value': 36.87 * Math.PI / 180 },
            { 'id': 'angleB', 'value': 53.13 * Math.PI / 180 },
            { 'id': 'angleC', 'value': 90 * Math.PI / 180 }
        ]
    },
    {
        'testCase': 'side angle angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleB', 'value': (53.13 * Math.PI / 180) },
            { 'id': 'angleC', 'value': (90 * Math.PI / 180) }
        ],
        'output': [
            { 'id': 'angleA', 'value': 36.87 * Math.PI / 180 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    },
    {
        'testCase': 'side side angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'angleC', 'value': (90 * Math.PI / 180) }
        ],
        'output': [
            { 'id': 'angleA', 'value': 36.87 * Math.PI / 180 },
            { 'id': 'angleB', 'value': 53.13 * Math.PI / 180 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    },
    {
        'testCase': 'pair and angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleA', 'value': (36.87 * Math.PI / 180) },
            { 'id': 'angleB', 'value': (53.13 * Math.PI / 180) }
        ],
        'output': [
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 },
            { 'id': 'angleC', 'value': 90 * Math.PI / 180 }
        ]
    },
    {
        'testCase': 'pair and side',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleA', 'value': (36.87 * Math.PI / 180) },
            { 'id': 'lengthB', 'value': 4 }
        ],
        'output': [
            { 'id': 'angleB', 'value': 53.13 * Math.PI / 180 },
            { 'id': 'angleC', 'value': 90 * Math.PI / 180 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    }
];
