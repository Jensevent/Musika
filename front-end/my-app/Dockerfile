FROM node:17-alpine

WORKDIR /app

COPY front-end/my-app ./

RUN npm install

RUN npm run build

COPY . .

CMD ["node", "run", "start"]
