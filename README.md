# AçãoCo - Sistema de Apoio Cívico contra Perturbações Sonoras

## 📝 Descrição do Projeto

O **AçãoCo]** é um sistema inovador de backend projetado para amenizar os problemas causados por perturbações sonoras urbanas, como bailes funk, através da mobilização comunitária e do registro facilitado de ocorrências para autoridades.

Nosso objetivo é empoderar vítimas de poluição sonora, oferecendo uma plataforma onde elas possam registrar anonimamente incidentes e, crucialmente, permitir que outros membros da comunidade (ajudantes) visualizem essas ocorrências em sua proximidade e apoiem o processo de denúncia junto à polícia ou outras autoridades competentes.

Acreditamos que, ao centralizar as informações e fomentar a colaboração cidadã, podemos criar um ambiente urbano mais tranquilo e respeitoso para todos.

---

## ✨ Objetivo da Aplicação

O principal objetivo do **AçãoCo** é:

- Amenizar os problemas com bailes funk e perturbações sonoras em comunidades urbanas.
- Capacitar as vítimas a registrar denúncias de forma simples e anônima.
- Fomentar a ação cívica e a solidariedade ao permitir que vizinhos e "ajudantes" contribuam para a resolução do problema.
- Agilizar o processo de denúncia ao fornecer dados centralizados e acessíveis para facilitar o contato com as autoridades.
- Restabelecer o direito ao sossego e promover a harmonia nas vizinhanças.

---

## 🚀 Como Funciona na Prática: Um Guia de Uso

### Para a Vítima (Usuário Registrado):

1. **Cadastro e Acesso Seguro**  
   A vítima se cadastra no sistema usando um pseudônimo e uma senha, garantindo sua privacidade. Após o cadastro, pode fazer login a qualquer momento.

2. **Registro de Ocorrência**  
   Informa a localização (latitude/longitude), data e hora do incidente, descrição textual, obstrução da via e número aproximado de pessoas. Todas as ocorrências começam como "Ativas".

3. **Anexar Fotos (Opcional)**  
   Se disponível, é possível anexar fotos para documentar melhor o incidente.

4. **Gerenciamento da Ocorrência**  
   A vítima pode visualizar e encerrar suas ocorrências manualmente.

5. **Desativação Automática**  
   Ocorrências são automaticamente desativadas após 8 horas, caso não sejam encerradas antes.

---

### Para o Ajudante (Usuário da Comunidade):

1. **Acesso Rápido e Sem Cadastro**  
   Basta informar a localização (ou permitir localização automática) para ver ocorrências ativas em até 3km.

2. **Visualização Detalhada**  
   Pode ver os dados da ocorrência: local, descrição, tipo de perturbação, obstrução, etc.

3. **Apoio à Denúncia**  
   Com essas informações, o ajudante pode acionar as autoridades com dados mais completos e confiáveis.

---

### Para o Administrador (Gestão e Supervisão):

1. **Controle Total**  
   Visualiza todas as ocorrências (ativas, encerradas manualmente ou automaticamente).

2. **Gestão de Ocorrências**  
   Pode alterar o status de qualquer ocorrência conforme necessário.

3. **Acesso a Dados de Usuários**  
   Pode visualizar o perfil de qualquer usuário registrado.

---

## 💻 Tecnologias Utilizadas

### Linguagem de Programação
- **C# (.NET)**: Backend moderno, ideal para APIs RESTful de alta performance.

### Banco de Dados
- **MongoDB**: NoSQL flexível, com suporte a:
  - Esquemas dinâmicos (campos opcionais nas denúncias)
  - Consultas geoespaciais (raio de 3km com `MongoDB Geospatial`)

### Autenticação e Autorização
- **JWT (JSON Web Tokens)**: Segurança para autenticar e autorizar operações específicas para vítimas e administradores.

### Geolocalização
- **MongoDB Geospatial**: Permite buscas eficientes por raio com dados de latitude/longitude.

### Cache (Futuro/Escalabilidade)
- **Redis (planejado)**: Para sessões, rate limiting e caching de dados mais acessados, aumentando a performance do sistema em escala.

### Orquestração de Containers
- **Docker / Docker Compose**: Facilita o desenvolvimento e a implantação com containers para backend e banco de dados.

