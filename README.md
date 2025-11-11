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
4. O arquivo k8sdeployment.yaml já contem todas as configurações necessárias para expor a api na porta 8002 , basta alterar o arquivo na sessão service-> spec -> ports -> port para a porta desejada caso a porta 8002 já esteja em uso na sua máquina
5. O repositório contém uma coleção postman com todos os endpoints mapeados e ordenados para uso.
6. A aplicação sobe com seed de dois usuários já cadastrados sendo eles : 
`   new UserMapping { Id = Guid.Parse("2712be0f-6146-4f74-b66e-dec1bb84fa8c"), Name = "Dev", Account = "dev@taskmanagerapp.com", Role = Domain.Enums.UserRole.Developer },
   new UserMapping { Id = Guid.Parse("df737e18-1699-4626-a8fd-54b450fe69d8"), Name = "Manager", Account = "manager@taskmanagerapp.com", Role = Domain.Enums.UserRole.Manager } }`
7. Comece o fluxo criando um projeto para um desses usuarios
8. Busque os projetos cadastrados para esse mesmo usuário
9. Utilize o id do projeto retornado no nó data.projects[0].id para criar uma nova task para o projeto
10. Busque as tasks do projeto retornado no passo 8
11. Utilize o id da task retornada no nó data.tasks[0].id para alterar , deletar ou adicionar comentários a task
12. Busque as tasks do projeto retornado no passo 8 a qualquer momento para verificar o historico de alterações das tasks e os comentarios adicionados.
13. Utilize o endpoint "Obter Relatorios" informando no header da requisição "logged-user-id" o id "df737e18-1699-4626-a8fd-54b450fe69d8" e no parametro da query o id "2712be0f-6146-4f74-b66e-dec1bb84fa8c" para obter o relatorio de performance do usuario "2712be0f-6146-4f74-b66e-dec1bb84fa8c"
14. Caso tente utilizar o endpoint "Obter Relatorios" informando no header da requisição "logged-user-id" o id "2712be0f-6146-4f74-b66e-dec1bb84fa8c" o sistema deve retornar erros.


