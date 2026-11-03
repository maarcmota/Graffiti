# Malbers Animations — Resumo do Animal Controller

> Resumo prático do **Animal Controller (AC)**, o framework de personagens da Malbers Animations. O projeto também inclui prefabs e cenas de exemplo. Este documento resume os conceitos; para detalhes de cada campo e diferenças entre versões, consulte o manual oficial.

## O que é

O Animal Controller é um framework para controlar movimento, animação, ações e comportamento de personagens no Unity. Pode ser usado com animais, criaturas e humanoides, desde que o modelo e as animações estejam configurados para o controlador.

O AC não é apenas um conjunto de modelos ou animações: o componente central, `MAnimal`, coordena o Animator, a física e os módulos de comportamento. A maior parte da configuração é feita no Inspector usando assets e componentes reutilizáveis, sem precisar criar um script novo para cada personagem.

O framework pode trabalhar com animações **Root Motion** ou **In Place**. O resultado depende das animações e do Animator Controller configurados para aquele personagem.

## Conceitos centrais

O comportamento é organizado principalmente em **States**, **Modes** e **Stances**:

| Conceito | Função | Exemplos |
|---|---|---|
| **State** | Ação ou forma principal de movimento ativa do personagem. | Idle, Locomotion, Jump, Fall, Swim, Fly, Climb, Death |
| **Mode** | Ação executada sobre o State atual. | Ataque, esquiva, lançar magia, usar item |
| **Stance** | Variação de postura ou estilo que altera como o personagem se comporta/anima. | Combate, agachado, ferido |

Em termos simples: o **State** define o que o personagem está fazendo, o **Mode** define uma ação adicional, e a **Stance** define o estilo/postura. Os States e Modes precisam estar de acordo com os parâmetros, tags e transições do Animator Controller.

### States e movimento

Os States padrão cobrem diferentes tipos de locomoção e ações. Entre os exemplos documentados e incluídos no framework estão:

- **Idle** e **Locomotion**: parado e movimento em velocidades configuráveis.
- **Jump**, **Fall** e **Death**: salto, queda e morte.
- **Swim**, **Underwater**, **Fly** e **Glide**: natação, mergulho e movimento aéreo.
- **Climb**, **Ledge Grab**, **Wall Run**, **Slide** e **Rail Grind**: movimentos contextuais.

Nem todo personagem precisa de todos os States. Um animal terrestre simples pode usar apenas Idle, Locomotion, Jump e Fall; adicione outros conforme os movimentos e animações existentes.

O `MAnimal` também usa conjuntos de **Speeds** (por exemplo, Walk, Trot e Run) e **Pivots** para configurar ritmos e giros. Os valores e States associados devem corresponder às animações e à escala do modelo.

### Modes e habilidades

Um Mode agrupa habilidades/variações de animação que podem ser acionadas durante um State. Por exemplo, um Mode de ataque pode conter vários ataques. A ativação pode vir de Input, código, eventos ou lógica de IA, conforme a configuração.

As animações de Mode precisam usar o layer e os parâmetros esperados pelo Animator Controller do AC. O comportamento de Mode no Animator informa ao controlador quando a animação começa e termina. Se uma habilidade não toca ou não encerra, confira os IDs/índices, as transições, os parâmetros e os Behaviours ligados às animações.

## Personagem controlado pelo jogador

O `MAnimal` é a peça central do personagem. O componente de entrada envia comandos ao animal:

- **Malbers Input** fornece eixos de movimento e entradas nomeadas.
- **MInput** é uma opção sem eixos próprios, útil quando outro componente já controla o movimento.
- As entradas nomeadas são associadas a States, Modes ou outros componentes. O tipo de acionamento pode ser pressionar, segurar, soltar, pressionar por mais tempo, toque duplo ou alternância, dependendo da configuração.
- O AC pode ser integrado ao Unity Input System; o projeto inclui assets de Input e exemplos.

Use um componente de Input para o jogador. Para personagens de IA, normalmente o movimento e as ações são controlados pelo sistema de IA, não pelo componente de entrada do jogador.

## IA

O **Animal Brain** permite montar comportamentos de IA com assets:

- **AI States** representam comportamentos de alto nível, como patrulhar, perseguir ou fugir.
- **Tasks** executam ações, como mover até um destino, patrulhar waypoints, mudar velocidade, tocar um Mode, definir alvo ou esperar.
- **Decisions** verificam condições para continuar ou trocar de comportamento, como distância, alvo, State, Mode, Stat ou tempo de espera.
- Componentes auxiliares podem controlar movimento, percepção/alvo, waypoints e áreas de caminhada.

O Brain organiza a lógica; o controle de movimento e os componentes de navegação precisam estar configurados para o cenário. As cenas de demonstração de IA do projeto são bons exemplos para comparar com o personagem desejado.

## Stats, dano e combate

O componente **Stats** gerencia valores numéricos identificados por `StatID`, como vida, stamina, mana ou dano. Um Stat pode ter limites, multiplicador, regeneração/degradação, imunidade temporária e eventos quando muda, chega ao mínimo/máximo ou cruza um limite.

Esses eventos permitem conectar, por exemplo, vida vazia ao State de morte ou uma alteração de Stat à interface. Stats podem ser usados em objetos além de personagens, como armas, escudos e objetos destrutíveis.

O framework inclui componentes de dano e reação, além de Modes para ataques. A animação e os gatilhos de ataque devem estar sincronizados: verifique colliders/triggers, camadas, eventos de animação, alvo e configuração de damager/damageable quando o ataque não causa efeito.

### Itens e equipamentos

O manual atual descreve o **Super Item System** para organizar itens, armas, ações, projéteis, slots/holsters e processadores. Ele pode ser usado para ataques corpo a corpo, armas à distância, escudos, bloqueio, parry e equipamentos.

Como o sistema e os exemplos mudaram entre versões, siga a página de migração do manual quando encontrar componentes antigos, como o Weapon Manager. Evite misturar instruções de versões diferentes sem conferir os componentes disponíveis no projeto.

## Eventos, variáveis e reações

O AC oferece ferramentas de composição para conectar sistemas com menos dependência entre scripts:

- **MEvents** são eventos baseados em assets que podem ser ouvidos por componentes na cena.
- **Scriptable Variables** permitem compartilhar valores, como bool, float, vetor ou referência de objeto.
- **Runtime Sets** mantêm conjuntos de objetos ativos, por exemplo jogadores ou inimigos.
- **Reactions** executam ações configuradas, como alterar um State, Stat, velocidade, gravidade, posição ou parâmetro de Animator.
- **Conditions** verificam condições e podem combinar resultados com AND/OR.
- **Zones** e componentes de interação podem disparar ações ao entrar, sair ou interagir.

Use esses recursos quando a lógica puder ser montada no Inspector. Para comportamento específico do jogo, scripts próprios continuam sendo apropriados; as extensões do AC podem chamar ou ser chamadas pelo código.

## Configuração básica e cuidados

Ao montar um personagem, use o prefab apropriado quando possível e confira estes pontos:

1. **Hierarquia e componentes:** o `MAnimal`, o `Animator` e o `Rigidbody` devem estar no mesmo nível, conforme o manual.
2. **Animator:** use o Animator Controller compatível com o AC e verifique State tags, parâmetros, layers, transições e animações.
3. **Physics:** o manual recomenda o Animator em **Animate Physics** com Rigidbody. O AC controla a rotação do personagem; confira as constraints do Rigidbody.
4. **Colliders:** ajuste-os ao corpo e ao tipo de personagem. Um collider na raiz que encoste no chão pode causar deslizamento em inclinações.
5. **Camadas:** o AC usa uma layer de Animal por padrão; confira a hierarquia, os raycasts, os triggers e as camadas ignoradas pelo projeto.
6. **Animações:** verifique se são Root Motion ou In Place e se o State/Modes estão preparados para esse tipo de movimento.
7. **Inputs e referências:** confirme que nomes/IDs dos Inputs, States, Modes e Stances correspondem aos assets e parâmetros usados pelo personagem.
8. **Testes incrementais:** comece com movimento básico; adicione salto, ações, Stats e IA um sistema por vez.

Essas são recomendações gerais do manual; prefabs de demonstração podem ter configurações adicionais próprias.

## O que existe neste projeto

O repositório contém a pasta `Assets/Malbers Animations`, incluindo scripts do Animal Controller, assets de States e exemplos de personagens. Entre os prefabs disponíveis estão:

- **Human**: prefabs de jogador, IA e versões mobile.
- **Wolf Lite**: prefabs de jogador, IA, inimigo e versões mobile.
- **Empty Controller**: base para montar um controlador.
- **Stats**: exemplos de configuração e interface de Stats.
- **1 - Demos**: cenas de demonstração do controlador e da IA, incluindo interações, movimento top-down/point-click, plataforma 2.5D, voo, morte ragdoll e outras mecânicas.

Prefira inspecionar as cenas e prefabs correspondentes antes de reproduzir uma configuração do zero. O README do pacote aponta para o manual e para a documentação de integrações.

## Roteiro sugerido de aprendizado

1. Abra um prefab de jogador ou a cena de demonstração mais próxima do seu caso.
2. Entenda o `MAnimal`, o Animator e o conjunto de Speeds.
3. Faça funcionar movimento e Input antes de adicionar States extras.
4. Configure Modes e confira suas transições no Animator.
5. Adicione Stats, dano, itens e interações conforme a necessidade do jogo.
6. Para NPCs, estude o prefab/cena de IA e monte AI States, Tasks e Decisions.
7. Só então personalize ou crie States, Modes, Reactions, Tasks e componentes próprios.

## Documentação oficial

- [Manual do Animal Controller](https://malbersanimations.gitbook.io/animal-controller/)
- [Features e visão geral dos sistemas](https://malbersanimations.gitbook.io/animal-controller/features)
- [Animal Controller (`MAnimal`)](https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller)
- [States](https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/states)
- [Modes](https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/modes)
- [Malbers Input e MInput](https://malbersanimations.gitbook.io/animal-controller/main-components/malbers-input)
- [IA](https://malbersanimations.gitbook.io/animal-controller/main-components/ai)
- [Stats](https://malbersanimations.gitbook.io/animal-controller/global-components/stats)
- [Super Item System](https://malbersanimations.gitbook.io/animal-controller/how-to-super-item)
- [Integrações oficiais](https://malbersanimations.gitbook.io/animal-controller/annex/integrations)
- [Changelog](https://malbersanimations.gitbook.io/animal-controller/annex/changelog)

> **Versão:** a página inicial do manual indicava Animal Controller **1.5.3b** quando este resumo foi escrito; várias páginas de referência são identificadas como atualizadas para **1.5.3**. Confirme a versão dos arquivos instalados no projeto antes de seguir instruções específicas de versão. Os nomes de sistemas e opções podem variar entre versões.
