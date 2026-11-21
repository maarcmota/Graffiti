# Zona Show — Vertical Slice Alpha

Com base no GDD, o protótipo será um **vertical slice de uma missão de aproximadamente 12 minutos**, não uma versão completa do jogo.

## Objetivo do protótipo

- Validar a diversão do ciclo central de base, missão, infiltração, graffiti, extração e progressão.
- Verificar se a pintura é agradável e fácil de entender.
- Testar stealth, alerta, distração e múltiplas abordagens em uma fase pequena.
- Confirmar que é possível concluir o objetivo sem matar inimigos.
- Identificar riscos técnicos antes de escalar para as 55 missões planejadas.
- Pragmatismo sobre oque acontece sobre esses 12 minutos de gameplay.

## 1. Fase pequena e completa

- [ ] Criar um mapa linear ou semiaberto.
- [ ] Definir cerca de três formas de acesso.
    - Criar entrada frontal.
    - Criar entrada traseira.
    - Criar uma entrada ou rota alternativa.
- [ ] Adicionar áreas para explorar e se esconder.
- [ ] Configurar uma situação inicial.
- [ ] Configurar objetivo principal.
- [ ] Configurar conclusão e extração.
- [ ] Fazer a missão reiniciar completamente ao ser reiniciada.
- [ ] Validar a rejogabilidade descrita nas seções 2.4 e 2.5 do GDD.

## 2. Sistema básico de stealth

- [ ] Implementar movimentação em primeira ou terceira pessoa.
- [ ] Implementar agachar.
- [ ] Implementar movimento silencioso.
- [ ] Permitir que o jogador se esconda.
- [ ] Exibir a área de visão dos inimigos.
- [ ] Implementar distratores ambientais ou de equipamento.
- [ ] Criar estado de investigação.
- [ ] Criar estado de procura.
- [ ] Criar estado de combate.
- [ ] Criar pelo menos um inimigo que investigue ruídos.
- [ ] Fazer o inimigo patrulhar e reagir a alertas.
- [ ] Validar o comportamento descrito na seção 6 de IA do GDD.

## 3. Mecânica central de graffiti

- [ ] Permitir pintar em uma parede.
- [ ] Adicionar contorno pontilhado ou guia de preenchimento.
- [ ] Permitir controle manual do preenchimento.
- [ ] Medir a precisão ao concluir o graffiti.
- [ ] Exibir o resultado entre **Rock** e **Toy**.
- [ ] Usar 50% como limite provisório de aprovação.
- [ ] Criar inventário limitado de tintas.
- [ ] Criar inventário limitado de cores.
- [ ] Validar a satisfação visual e tátil da pintura.
- [ ] Validar a mecânica conforme a seção 2.3 do GDD.

## 4. Objetivo principal da missão

Uma missão de exemplo poderá combinar os seguintes elementos:

- [ ] Entrar pela entrada frontal, traseira ou alternativa.
- [ ] Evitar inimigos.
- [ ] Neutralizar inimigos de forma não letal.
- [ ] Pintar uma ou duas superfícies.
- [ ] Recuperar um objeto.
- [ ] Coletar uma parte narrativa ou artefato.
- [ ] Extrair pela entrada escolhida ou por uma rota alternativa.
- [ ] Permitir concluir a missão sem matar.

## 5. Combate mínimo

- [ ] Implementar vida. A barra de vida permanece oculta
- [ ] Implementar dano. O jogador tem uma chance a mais
- [ ] Implementar cura passiva.
- [ ] Implementar morte. Por contato com inimigos.
- [ ] Adicionar pistola tranquilizante ou rifle de tinta.
- [ ] Adicionar granada de fumaça como distração.
- [ ] Garantir pelo menos uma opção de arma não letal.
- [ ] Permitir reiniciar após derrota.
- [ ] Priorizar uma conclusão furtiva ou não letal.

## 6. Progressão reduzida

Para não construir todo o sistema de RPG:

- [ ] Criar uma barra ou sistema de respeito.
- [ ] Criar um ou dois upgrades simples.
- [ ] Desbloquear uma ferramenta, como escada ou caixa.
- [ ] Fazer um upgrade abrir uma rota antes bloqueada.
- [ ] Coletar recursos durante a missão.
- [ ] Converter recursos em uma pequena recompensa na base.
- [ ] Validar a progressão descrita na seção 2.1 do GDD.

## 7. Mother Base mínima (Zona Show)

- [ ] Criar uma tela simples da base.
- [ ] Criar uma edificação de exemplo.
- [ ] Representar visualmente o estado vazio da edificação.
- [ ] Representar visualmente o estado construído da edificação.
- [ ] Permitir selecionar a missão.
- [ ] Exibir equipamentos disponíveis.
- [ ] Exibir upgrades disponíveis.
- [ ] Validar o conceito básico descrito em 2.1.2 Zona Show.

## 8. Interface essencial

- [ ] Exibir vida.
- [ ] Exibir estado de alerta.
- [ ] Exibir quantidade de tinta.
- [ ] Exibir cores disponíveis.
- [ ] Exibir objetivo ativo.
- [ ] Indicar movimento silencioso.
- [ ] Permitir visualização diagnóstica da área de visão.
- [ ] Criar tela de armamento antes da missão.
- [ ] Criar tela de pausa.
- [ ] Criar opção de reinício.
- [ ] Validar melhorias futuras descritas na seção 5.5 do GDD.

## 9. Elementos narrativos

Um protótipo não precisa conter toda a história, mas pode apresentar:

- [ ] Introdução curta em vídeo
- [ ] Adicionar Lego como protagonista.
- [ ] Adicionar Shotgun como parceiro.
- [ ] Relacionar a missão às operações de 2000.
- [ ] Inserir uma pista sobre a fraude eleitoral.
- [ ] Adicionar diálogos radiofônicos curtos.
- [ ] Validar a apresentação descrita nas seções 4.1 e 4.2 do GDD.

## 10. Apresentação visual mínima

- [ ] Utilizar ambiente 3D estilizado.
- [ ] Evitar realismo excessivo.
- [ ] Utilizar formas simplificadas.
- [ ] Utilizar uma paleta expressiva.
- [ ] Contrastar superfícies pintáveis com o restante do cenário.
- [ ] Criar efeito visual para alertas.
- [ ] Criar efeito visual para precisão.
- [ ] Fazer o blockout da Zona Show.
- [ ] Adicionar som de passos.
- [ ] Adicionar som de alerta.
- [ ] Adicionar som de pintura.
- [ ] Adicionar som de coleta ou obtenção de tinta.
- [ ] Validar a direção descrita na seção 3.1 do GDD.

## 11. Escopo técnico

- [ ] Usar Unity com URP.
- [ ] Construir para PC offline.
- [ ] Usar third-person controller.
- [ ] Implementar uma arma não letal ou disruptiva.
- [ ] Implementar uma IA simples baseada em estado.
- [ ] Implementar save entre base e missões.
- [ ] Não incluir multiplayer.
- [ ] Não incluir bosses completos.
- [ ] Não incluir os cinco artefatos completos.
- [ ] Não incluir todas as 55 missões.
- [ ] Não incluir personalização pesada de armas.
- [ ] Não incluir final completo.

## 12. Critérios de validação

- [ ] Pintar é agradável e gera vontade de repetir a ação?
- [ ] O jogador entende quando está escondido ou exposto?
- [ ] As múltiplas rotas são legíveis e satisfatórias?
- [ ] É possível concluir o objetivo sem matar?
- [ ] O limite de aproximadamente 12 minutos cria pressão sem ansiedade excessiva?
- [ ] O ciclo base → missão → tinta → progresso → missão é divertido?
- [ ] A progressão muda a abordagem do jogador em pelo menos uma situação?
- [ ] A consequência de detecção é compreensível e rápida sem parecer injusta?
- [ ] A possibilidade de reiniciar ou continuar preservando progresso reduz a frustração sem eliminar o risco?

## Escopo recomendado

Uma única missão com:

- [ ] Três entradas.
- [ ] Uma parede central pintável.
- [ ] Dois tipos de inimigo no máximo.
- [ ] Um upgrade funcional.
- [ ] Uma rota desbloqueada por esse upgrade.
- [ ] Um objetivo principal claro.
- [ ] Uma conclusão furtiva possível.
- [ ] Uma extração funcional.