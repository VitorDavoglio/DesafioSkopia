# .NET Developer Senior - Skopia

**Introdução:**

O Projeto abaixo replica os comportamentos solicitados no seguinte teste : https://meteor-ocelot-f0d.notion.site/NET-C-5281edbec2e4480d98552e5ca0242c5b

**O Projeto busca comprovar proficiencia nos seguintes temas:**

1. Orientação a objeto.
2. Clean Code.
3. Manutenabilidade.
4. DDD.
4. Design Patterns.

**Soluções adotadas:**
1. Injeção de dependencia e Inversão de controle.
2. In Memory DB do EFCore9 como banco de dados.
3. Adicionado pacote MediatR para implementação de pattern CQRS e Mediator.
4. Api documentada utilizando swagger.
5. Separação de responsabilidades de Negócio e Aplicação.
7. Implementação em multiplas Dlls para facilitar reaproveitamento e eventualmente distribuição dos pacotes.
8. Adoção de um padrão de respostas da API tanto para casos de sucesso quanto para casos de erro.
9. Implementação de filtro de roles baseado no banco de dados para o endpoint de Relatórios.
10. Implementação de filtro global para excessões.
11. Adoção de .NET 9 como framework de desenvolvimento.
12. Aplicação containerizada via Docker
13. Implantação e orquestração do projeto utilizando K8s.

# Sugesões de Refinamento:

1. Conforme documento no link : https://meteor-ocelot-f0d.notion.site/NET-C-5281edbec2e4480d98552e5ca0242c5b a aplicação contém a habilidade de adicionar comentários a tasks , mas não contempla remoção ou atualização dos mesmos, o que seria uma feature interessante.
2. Não foram solicitados Logs , que são essenciais em ambientes produtivos.
3. As tasks não possuem informação de estimativa e na minha visão essa é uma feature que adiciona muito valor a gestão.
5. O relatório de desempenho leva em consideração somente um usuário , seria interessante poder visualizar o desempenho do projeto como um todo.
6. O relatório poderia ser exportado para XLSX ou CSV
7. A task não possui um responsável , e o projeto não permite mais de um usuário.

# Como Executar o Projeto: 
1. Em uma maquina com docker instalado executar o comando `docker build -t tsk-mgmt-api -f ./DockerFile .` a partir da pasta raiz da solução
2. Após gerada a imagem executar o comando de aplicação do manifesto k8s `kubectl apply -f .\k8sdeployment.yaml`
3. Caso necessário ajustar a variavel ConnectionStrings__TaskManagerDb do arquivo k8sdeployment.yaml para que aponte para o banco de dados da sua preferencia.
4. O arq
