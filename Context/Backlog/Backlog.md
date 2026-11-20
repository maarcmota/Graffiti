## Direção geral

GG: Uma boa ideia, com alta complexidade, mecânicas simples e escaláveis, para um público específico, em um formato palpável e por um preço acessível.

- Ser pragmático e metódico sobre como o jogador vai interagir com o game (SPINE).
- Mostrar o core loop no trailer.
- Efeito viral: medidor de blue pill e red pill.
- Collabs: avaliar o alcance da ideia e sua relação com jogos brasileiros.

## ITENS

Todos os itens, incluindo as armas, têm um ID, um nome e um preço, que pode ser 0.

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

- [ ] Ter o main core loop de espionagem muito bem descrito.
- [x] Mapear todas as conversas sobre o jogo: WhatsApp, notas e documentos.
- [ ] Reunir e organizar o game design já produzido.

## 1. PROTÓTIPO DE PLATAFORMA

### 1.2 Sistema de missão e loop central

O objetivo do loop central é tentar fazer pelo menos uma missão ou pegar um item, além de fazer o máximo de graffiti possível até a tinta acabar e, então, extrair.

- [ ] Decidir a abordagem da missão na tela de armamento e fornecer ao jogador as informações sobre a operação.
- [ ] Implementar a morte e a tela de Game Over e reiniciar o save.

- [ ] Implementar o sistema de itens.
- [ ] Implementar carga de tinta para prosseguir pelas missões.

- [ ] Implementar o sistema de dia e noite. Cada missão avança o horário.
  - [ ] Manhã na base.
  - [ ] Tarde em missão.
  - [ ] Entardecer na base.
  - [ ] Noite em missão.

### 1.3 Graffiti

- [ ] Implementar o sistema de graffiti.
- [ ] Pokédex (Black Book) — Colecionar todos os graffitis já feitos e suas informações.
  - Registrar a última vez em que foram feitos.
  - Fazer o mesmo graffiti 15 vezes aumenta a durabilidade visual na parede.
  - O objetivo é mostrar a parede completamente preenchida após a ação se repetir.

- [ ] Pesquisar elementos de satisfação de Death Stranding para aplicar ao graffiti e à entrega.
- [ ] Apresentar uma guia em baixa opacidade para auxiliar o jogador.
  - Preenchimento.
  - Linha pontilhada (contorno).

- [ ] Medidor de precisão mostrado ao fim da missão. O resultado pode ser “Rock” ou “Toy”, dependendo da porcentagem de aprovação, definida em 50%.

- [ ] Grafites mais complexos são feitos com base no material disponível. Quanto melhores forem os materiais carregados, maior será a qualidade do graffiti. As cores também são limitadas às disponíveis para o jogador.
- [ ] Graffitis específicos concedem buffs ao jogador.
- [ ] (Técnico) Máscara RGB para fazer o graffiti e definir a cor na shader.


### 1.4 Vida, combate e inimigos

- [ ] Implementar vida, dano, cura, morte e ataques.
- [ ] Implementar sistema de inimigos.
- [ ] Implementar perseguidores.
- [ ] Ter inimigos exclusivos de determinadas áreas.
- [ ] Mostrar a área de visão do mob enquanto o jogador permanece parado (acesso por meio de upgrade).
- [ ] Incluir viciados em pílulas em Zona Show.

### 1.5 Bosses

- [ ] Criar quantos bosses forem necessários.
- [ ] Definir mecânicas específicas depois de validar o protótipo.
- [ ] Usar provisoriamente a seguinte mecânica básica:
  - O boss fica raivoso.
  - O jogador o cega com tinta.
  - O boss colide contra as paredes da arena.
  - Após 3 a 5 colisões, o boss é derrotado.

## 2. SISTEMAS E PROGRESSÃO

A meta é o power creep. A moeda do jogo se chama Níquel (pentágono).

### 2.1 Zona Show

O jogador possui sua área chamada Zona Show. Inspirada em Metal Gear Solid V: The Phantom Pain, essa base contém diversas edificações, e cada uma cumpre um papel específico na progressão.

- [ ] Cada edificação possui mais de um nível. O nível base é representado visualmente por um terreno vazio. Os demais níveis apresentam o edifício evoluindo.
- [ ] Fazer os upgrades desbloquearem itens que ajudam a atravessar passagens antes bloqueadas.
- [ ] Implementar a tela com todos os níveis (mapa).

### 2.2 Quadro de Evolução

Respeitos → efeitos permanentes ou desbloqueio de mecânicas.

O nível de respeito concede pontos de respeito. É preciso completar uma linha inteira de upgrades para desbloquear a próxima. Alguns upgrades também possuem mais de um nível e afetam a porcentagem da passiva.

- 01 LVL - Nome
    Item ou Passiva
- 02 LVL - Nome
    Item ou Passiva


### 2.3 Armeiro

- [ ] Fazer a progressão ficar gradualmente mais RPG conforme o jogador equipa attachments na arma.
- [ ] Mira habilita a exibição dos números de dano.
- [ ] Implementar projetil colorido.

### 2.4 Mecânicas de rastreamento e interface

- [ ] Celular auxilia o jogador a rastrear todos os aspectos do jogo que não possuem interface própria.
- [ ] Quando ficar parado, mostrar a área de visão do mob.
- [x] Implementar debug log. (Chat)
- [ ] Fazer os botões da interface piscarem para melhorar a UX e ajudar o jogador a não ficar preso nos menus.
- [ ] Definir o número máximo de palavras por diálogo: 80 palavras, com no máximo 10 telas e 8 palavras por tela.

## 3. NARRATIVA E PERSONAGENS

### 3.1 Pesquisa narrativa

- [x] Resumir: durante uma ditadura militar, surge o movimento hip-hop.
- [ ] Conceber personagens.
- [ ] Escrever as possíveis narrativas.
- [ ] Criar um baralho de 55 cartas para contar uma história.

### 3.2 Personagens

- Shotgun — coadjuvante, mentor e parceiro de Lego do protagonista.
  > “Na verdade, esse personagem não existe; ele apenas reflete as vontades do protagonista.” — Revolucionário
- IT Guy
- Líder de Umbanda — Recebe o jogador na Zona Show.
- Fest — personagem ligado aos trens e ao graffiti.
- Vendedor Esquisito — analisa itens miscelâneos.

### 3.3 Artefatos e Cthulhu

- [ ] Desenvolver a história dos artefatos.
- [ ] Fazer o jogador reunir cinco partes ao longo da jornada.
- [ ] O conjunto construirá o artefato que evocará Cthulhu.
- [ ] Fazer o Shotgun, o coadjuvante, acompanhar o jogador na coleta dos artefatos.
    - 1. Espelho (celular)
    - 2. Pedra da Fortificação
    - 3.
    - 4.
    - 5.
- [ ] Revelar ao final que o Shotgun é uma imagem projetada do subconsciente do próprio protagonista.

### 3.4 Formato da história

Uma parte da história será contada por imagens em movimento que marcam o início e o fim dos capítulos. Essa decisão reúne as opções disponíveis: história em cutscene, história em quadrinhos ilustrada ou história em vídeo.

## 4. FINAIS

### Opção 1

- [ ] Permitir escolher entre final bom e final ruim.
- [ ] Implementar o final bom: aprisionar Cthulhu para sempre usando o poder dos artefatos.
- [ ] Implementar o final ruim: invocar Cthulhu e deixá-lo governar o mundo.
- [ ] Independentemente da escolha, retornar ao estágio anterior à última missão.
- [ ] Permitir jogar livremente depois do fim e refazer a escolha.

### Opção 2

- [ ] O jogador confronta o ditador ou a ditadora e passa por uma morte do ego quando a verdade lhe é revelada: seu parceiro era apenas um amigo imaginário. Em sua busca por poder, o protagonista se tornou pior e mais ganancioso do que seu inimigo.

### Opções adicionais

- [ ] Considerar um final aberto para Zona Show 2.
- [ ] Considerar o final romântico: o par do jogador é raptado em algum ponto do jogo e resgatado ao final.

## 5. APRESENTAÇÃO VISUAL

- [ ] Double exposure
- [ ] Configurar o contraste de Zona Show com cuidado.
- [ ] Criar moodboard dos personagens.
- [ ] Aplicar efeito Kuwahara. (Talvez com uma abordagem diferente)
- [ ] Criar efeito VFX de pulso para usar como efeito base na prototipagem.
- [ ] Fazer o blockout da Zona Show.

## 6. PESQUISA E APRENDIZADO

- [ ] Reunir referências de Zona Show.
- [ ] Ler a documentação do Malbers Animal Controller.
- [ ] Aprender ProBuilder.
- [ ] Integrar Zona Show no Unity + FAB.
- [ ] Estudar como desenhar pixel art dentro do Unity.
- [ ] Estudar Blender Geometry Nodes.
- [ ] Fazer curso de áudio.
- [ ] Fazer curso de roteiro.
- [ ] Estudar como combinar meshes no Blender *([link do 80.lv](https://encurtador.com.br/iqMD))*.

## IDEIAS REJEITADAS OU NÃO PRIORITÁRIAS

- O efeito ModPsyco. Iridescente.
- INFINITY RUNNER: ideia desconectada do escopo atual de plataforma e espionagem.
- Super Battle Golf — movimentação: referência visual ou mecânica que ainda não pertence ao core loop.