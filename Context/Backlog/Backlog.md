## Direção geral

GG: Uma boa ideia, com alta complexidade, mecânicas simples e escaláveis, para um público específico, em um formato palpável e por um preço em conta.

- Ser pragmático e metódico sobre como o jogador vai interagir com o game (SPINE).
- Mostrar o core loop no trailer.
- Efeito viral: medidor de blue pill e red pill.
- Collabs: avaliar o alcance da ideia e sua relação com jogos brasileiros.

## ITENS
Todos os itens (incluindo as armas) têm um ID, um nome e um preço (que pode ser 0).

### Ferramentas

- Escada
- Caixa

### Tinta

- Balde de tinta e pincel
- Balde de tinta e rolo
- Lata spray de tinta

### Armas

- Pistola tranquilizante
- Rifle Paint Ball
- Bazooka de tinta
- Granada de fumaça de tinta

# ZONASHOW - Quadro de tarefas

## TAREFA PRINCIPAL

- [ ] Ter o Main Core Loop de espionagem muito bem descrito.
- [x] Mapear todas as conversas sobre o jogo: WhatsApp, notas e documentos.
- [ ] Reunir e organizar o game design já produzido.

## 1. PROTÓTIPO DE PLATAFORMA


### 1.2 Sistema de missão e loop central

Objetivo do loop central é tentar fazer pelo menos uma missão ou pegar um item. Também fazer o máximo de graffiti até a tinta acabar e depois extrair.

- [ ] Decidir a abordagem da missão na tela armamento - Dar ao jogador as informações sobre a operação.
- [ ] Implementar a morte e a tela de Game Over. Reiniciar o save.

- [ ] Implementar o sistema de itens.
- [ ] Implementar carga de tinta para prosseguir pelas missões.

- [ ] Implementar sistema de dia e noite. Cada missão avança o horário.
  - [ ] Manhã na base >
  - [ ] Tarde em missão. >
  - [ ] Entardecer na base. >
  - [ ] Noite em missão. >

### 1.3 Graffiti

- [ ] Implementar o sistema de graffiti.
- [ ] Pokedex (Black book) — Coleciona todos os graffitis já feitos, junto de informações a cerca deles.
    Qual foi a ultima vez feito
    - Fazer o mesmo graffiti 15 vezes aumentar a durabilidade visual na parede.
    - O objetivo é mostrar a parede completamente preenchida após a ação se repetir.

- [ ] Pesquisar elementos de satisfação de Death Stranding para aplicar ao graffiti e à entrega.
- [ ] Uma guia é apresentada em baixa opacidade para auxiliar o jogador
    - Preenchimento
    - Linha Pontilhada (Contorno)

- [ ] Medidor de precisão. É mostrado ao fim da missão. O resultado final pode ser dois: Rock or Toy, dependendo da porcentagem de aprovação (50%).

- [ ] Grafite mais complexo é feito com base no material de desenho. Quanto melhores os materiais que você carrega, de maior qualidade o graffiti. As cores também são baseadas nas que o jogador possui.
- [ ] Graffitis especificos lhe concedem buffs.
- [ ] (TECH) Mascara RGB para fazer o graffiti, assim definido a cor na shader.


### 1.4 Vida, combate e inimigos

- [ ] Implementar vida, dano, cura, morte e ataques.
- [ ] Implementar sistema de inimigos.
- [ ] Implementar perseguidores.
- [ ] Ter inimigos exclusivos de determinadas áreas.
- [ ] Mostrar a área de visão do mob enquanto o jogador permanece parado (Acesso atravéz de Upgrade).
- [ ] Incluir viciados em pílulas em Zona Show.

### 1.5 Bosses

- [ ] Criar quantos bosses forem necessários.
- [ ] Definir mecânicas específicas depois de validar o protótipo.
- [ ] Usar provisoriamente a seguinte mecânica básica:
  - O boss fica raivoso.
  - O jogador o cega com tinta.
  - O boss bate em trombadas nas paredes da arena.
  - Após 3 a 5 trombadas, o boss é derrotado.

## 2. SISTEMAS E PROGRESSÃO

A meta do powercreep. Seu dinheiro se chama Níquel (Pentagono)

### 2.3 Zona Show

O jogador possui sua area chamada Zona Show. Inspirado por Metal Gear Solid 5: The Phantom Pain, o nessa base existe diversas edificações, que cada uma cumpre um papel especifico na progressão. 

- [ ] Cada edificação possui mais de um nivel. O nivel base, é visualmente isso é representado como um terreno vazio. Os diversos niveis apresentam esse edificio evoluindo.
- [ ] Fazer upgrades desbloqueam itens, que te ajudam com passagens antes bloqueadas.
- [ ] Implementar a tela com todos os niveis (Mapa).

### 2.2 Quadro de Evolução

Respeitos → efeitos permanentes ou desbloqueio de mecânicas
    Nível de respeito. Concede ponto de respeito. É preciso completar uma linha inteira de upgrades para desbloquear a proxima. Alguns upgrades possuem também mais de um Nivel, e afeta a porcentagem da passiva.

- 01 lvl - Nome
    Item ou Passiva
- 02 lvl - Nome
    Item ou Passiva


### 2.3 Armeiro

- [ ] Fazer a progressão ficar gradualmente mais RPG conforme o jogador equipa attachments na arma.
- [ ] Mira habilita a exibição dos números de dano.
- [ ] Implementar projetil colorido.

### 2.4 Mecânicas de rastreamento e interface

- [ ] Celular auxilia o jogador a rastrear todos aspectos do jogo, que não possuem interface propria.
- [ ] Quando ficar parado, mostrar a área de visão do mob.
- [x] Implementar debug log. (Chat)
- [ ] Fazer os botões da interface piscarem para melhorar a UX e ajudar o jogador a não ficar preso nos menus.
- [ ] Definir número máximo de palavras por dialogo: 80 Palavras, sendo no maximo 10 telas com 8 palavras ao maximo por telas

## 3. NARRATIVA E PERSONAGENS

### 3.1 Pesquisa narrativa

- [x] Resumir: durante uma Ditadura Militar, surge o movimento Hip Hop.
- [ ] Concept de personagens
- [ ] Escrever as possíveis narrativas.
- [ ] Criar um baralho de 55 cartas para contar uma história.

### 3.2 Personagens

- Shotgun — Coadjuvante, Mentor e Parceiro de Lego (Protagonista). 
    > “Na verdade esse personagem não existe, ele apenas reflete as vontades do protagonista. - Revolucionário”
- IT Guy
- Líder de Umbanda — Recebe o jogador na Zona Show.
- Fest — Personagem ligado aos trens e ao graffiti
- Vendedor Esquisito — Analisa itens miscelanicos. 

### 3.3 Artefatos e Cthulhu

- [ ] Desenvolver a história dos artefatos.
- [ ] Fazer o jogador reunir cinco partes ao longo da jornada.
- [ ] O conjunto ira construir o artefato que evocará Cthulhu.
- [ ] Fazer o Shotgun (Coadjuvante) acompanhar o jogador na coleta dos artefatos. 
    - 1. Espelho (cel)
    - 2. Pedra da Fortificação
    - 3.
    - 4.
    - 5.
- [ ] Revelar ao final que o Shotgun é uma imagem projetada do subconsciente do próprio protagonista.

### 3.4 Formato da história

Uma parte da historia sera contada atravéz de imagens em movimento, que marcam o fim de inicio dos capitulos. Essa decisão é um conjunto das opções disponiveis. Opções: história em cutscene, história em quadrinhos ilustrada, história em vídeo.

## 4. FINAIS

1. 
- [ ] Permitir escolher entre final bom e final ruim.
- [ ] Implementar o final bom: aprisionar Cthulhu para sempre usando o poder dos artefatos.
- [ ] Implementar o final ruim: invocar Cthulhu e deixá-lo governar o mundo.
- [ ] Independente da escolha, retornar ao estágio anterior à última missão.
- [ ] Permitir jogar livremente depois do fim e refazer a escolha.

2. 
- [ ] O jogador confronta o(a) ditadora(o), fazendo isso o jogador passara por uma morte de ego, quando a verdade a ele for revela-da. Além de seu parceiro, ser apenas um amigo imaginario. Na sua busca por poder, você se tornou pior e mais ganancioso do que seu inimigo.

3. 
- [ ] Considerar um final aberto para Zona Show 2.
- [ ] Considerar o final romântico: o par do jogador é raptado, em algum ponto do jogo e resgatado ao final.

## 5. APRESENTAÇÃO VISUAL

- [ ] Double exposure
- [ ] Configurar o contraste de Zona Show com cuidado.
- [ ] Criar moodboard dos personagens.
- [ ] Aplicar efeito Kuwahara. (Talvez com uma abordagem diferente)
- [ ] Criar efeito VFX Pulso - usar como efeito base na prototipagem)
- [ ] Fazer Blockout do Zonashow.

## 6. PESQUISA E APRENDIZADO

- [ ] Reunir referências de Zona Show
- [ ] Ler a documentação do Malbers Animal Controller.
- [ ] Aprender ProBuilder.
- [ ] Integrar Zona Show no Unity + FAB.
- [ ] Estudar como desenhar pixel art dentro do Unity
- [ ] Estudar Blender Geometry Nodes
- [ ] Fazer curso de áudio.
- [ ] Fazer curso de roteiro.
- [ ] Estudar como blendar meshes no Blender *[(link do 80.lv)](https://encurtador.com.br/iqMD)*.

## IDEIAS REJEITADAS OU NÃO PRIORITÁRIAS
- O efeito ModPsyco. Iridescente.
- INFINITY RUNNER: ideia desconectada do escopo atual de plataforma e espionagem.
- Super Battle Golf — movimentação: referência visual ou mecânica que ainda não pertence ao core loop.