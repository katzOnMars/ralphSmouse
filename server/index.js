const app = require('express')();
const port = process.env.PORT || 8080;

app.get('/', (req, res) => res.json('hey'));

app.listen(port, () => console.log(`server up on ${port}`));
