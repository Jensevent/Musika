FROM node

WORKDIR /app

COPY "/front-end/my-app/package*.json" ./

RUN npm run build

COPY . .

CMD ["node", "npx serve -s build "]
