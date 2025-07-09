AçãoCo - Sistema de Apoio Cívico contra Perturbações Sonoras
📝 Descrição do Projeto
O AçãoCo é um sistema inovador de backend projetado para amenizar os problemas causados por perturbações sonoras urbanas, como bailes funk, através da mobilização comunitária e do registro facilitado de ocorrências para autoridades.

Nosso objetivo é empoderar vítimas de poluição sonora, oferecendo uma plataforma onde elas possam registrar anonimamente incidentes e, crucialmente, permitir que outros membros da comunidade (ajudantes) visualizem essas ocorrências em sua proximidade e apoiem o processo de denúncia junto à polícia ou outras autoridades competentes.

Acreditamos que, ao centralizar as informações e fomentar a colaboração cidadã, podemos criar um ambiente urbano mais tranquilo e respeitoso para todos.

✨ Objetivo da Aplicação
O principal objetivo do AçãoCo é:

Amenizar os problemas com bailes funk e perturbações sonoras em comunidades urbanas.

Capacitar as vítimas a registrar denúncias de forma simples e anônima.

Fomentar a ação cívica e a solidariedade ao permitir que vizinhos e "ajudantes" contribuam para a resolução do problema.

Agilizar o processo de denúncia ao fornecer dados centralizados e acessíveis para facilitar o contato com as autoridades.

Restabelecer o direito ao sossego e promover a harmonia nas vizinhanças.

O AçãoCo facilita a conexão entre quem sofre com a perturbação e quem pode ajudar a resolver, através de um fluxo simples e intuitivo:

Para a Vítima (Usuário Registrado):
Cadastro e Acesso Seguro: A vítima se cadastra no sistema usando um pseudônimo e uma senha, garantindo sua privacidade. Após o cadastro, ela pode fazer login a qualquer momento para acessar suas funcionalidades.

Registro de Ocorrência: Uma vez logada, a vítima pode registrar uma nova ocorrência de perturbação sonora. Ela informa a localização exata (latitude e longitude), a data e hora do incidente e pode adicionar detalhes importantes como uma descrição textual, se há obstrução da via e o número aproximado de pessoas no local. Todas as novas ocorrências são marcadas como "Ativas".

Anexar Fotos (Opcional): Se a funcionalidade estiver disponível, a vítima pode anexar fotos para documentar melhor o incidente.

Gerenciamento da Ocorrência: A vítima tem controle sobre suas próprias denúncias. Ela pode visualizar todas as ocorrências que registrou e, caso o problema seja resolvido ou ela deseje encerrar, pode desativar a ocorrência manualmente.

Desativação Automática: Para garantir que o sistema contenha informações relevantes e atualizadas, cada ocorrência é automaticamente desativada após 8 horas de seu registro, caso não seja desativada manualmente.

Para o Ajudante (Usuário da Comunidade):
Acesso Rápido e Sem Cadastro: O ajudante não precisa se cadastrar ou fazer login. Ele pode acessar o sistema e, ao informar sua localização (ou permitir que o aplicativo o localize), consegue verificar ocorrências ativas em um raio de até 3km de onde ele está.

Visualização Detalhada: Ao identificar uma ocorrência próxima, o ajudante pode visualizar seus detalhes (local, tipo de perturbação, descrição, se há obstrução etc.).

Apoio à Denúncia: Com as informações em mãos, o ajudante pode então apoiar a denúncia ligando para a polícia ou outras autoridades competentes, fornecendo dados precisos obtidos diretamente da plataforma, aumentando a eficácia da denúncia.

💻 Tecnologias Utilizadas
Este projeto de backend é construído com um conjunto de tecnologias modernas e robustas para garantir escalabilidade, performance e manutenibilidade.

Linguagem de Programação:

C# (.NET): Linguagem de backend poderosa e versátil, ideal para construir APIs RESTful de alto desempenho.

Banco de Dados:

MongoDB: Banco de dados NoSQL orientado a documentos, escolhido pela sua flexibilidade de esquema (ideal para campos opcionais nas ocorrências), escalabilidade horizontal e, crucialmente, pelo seu suporte nativo a consultas geoespaciais (MongoDB Geospatial), essenciais para a funcionalidade de "raio de 3km".

Autenticação e Autorização:

JWT (JSON Web Tokens): Utilizado para autenticação segura e stateless da API para usuários "Vítima" e "Administrador", garantindo que apenas usuários autorizados possam realizar certas operações.

Geolocalização:

MongoDB Geospatial: Componente intrínseco do MongoDB que permite o armazenamento e a consulta eficiente de dados baseados em localização, tornando a busca de ocorrências por raio rápida e eficaz.

Cache (Futuro/Escalabilidade):

Redis: Embora não seja um componente do MVP inicial, o Redis será considerado para camadas de caching (ex: sessões, dados frequentemente acessados, rate limiting) para otimizar a performance e reduzir a carga sobre o banco de dados principal conforme o sistema escala.

Orquestração de Containers:

Docker/Docker Compose: Utilizado para empacotar a aplicação e o banco de dados em containers, garantindo um ambiente de desenvolvimento consistente e facilitando o deployment.

Redis: Embora não seja um componente do MVP inicial, o Redis será considerado para camadas de caching (ex: sessões, dados frequentemente acessados, rate limiting) para otimizar a performance e reduzir a carga sobre o banco de dados principal conforme o sistema escala.

Orquestração de Containers:

Docker/Docker Compose: Utilizado para empacotar a aplicação e o banco de dados em containers, garantindo um ambiente de desenvolvimento consistente e facilitando o deployment.
