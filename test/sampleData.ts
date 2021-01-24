export const sampleData = [
    {
        'testCase': 'side side side',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 }
        ],
        'output': [
            { 'id': 'angleA', 'value': 36.87 },
            { 'id': 'angleB', 'value': 53.13 },
            { 'id': 'angleC', 'value': 90 }
        ]
    },
    {
        'testCase': 'side angle angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleB', 'value': 53.13 },
            { 'id': 'angleC', 'value': 90 }
        ],
        'output': [
            { 'id': 'angleA', 'value': 36.87 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    },
    {
        'testCase': 'side side angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'angleC', 'value': 90 }
        ],
        'output': [
            { 'id': 'lengthC', 'value': 5 },
            { 'id': 'angleA', 'value': 36.87 },
            { 'id': 'angleB', 'value': 53.13 }
        ]
    },
    {
        'testCase': 'pair and angle',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleA', 'value': 36.87 },
            { 'id': 'angleB', 'value': 53.13 }
        ],
        'output': [
            { 'id': 'angleC', 'value': 90 },
            { 'id': 'lengthB', 'value': 4 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    },
    {
        'testCase': 'pair and side',
        'input': [
            { 'id': 'lengthA', 'value': 3 },
            { 'id': 'angleA', 'value': 36.87 },
            { 'id': 'lengthB', 'value': 4 }
        ],
        'output': [
            { 'id': 'angleB', 'value': 53.13 },
            { 'id': 'angleC', 'value': 90 },
            { 'id': 'lengthC', 'value': 5 }
        ]
    }
];
