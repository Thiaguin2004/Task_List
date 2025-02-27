const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7025';

const PROXY_CONFIG = [
  {
    context: [
      "/projetos",
      "/usuarios",
      "/recursos",
      "/status",
      "/tarefas",
      "/tarefasrecursos",
      "/tipos"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
