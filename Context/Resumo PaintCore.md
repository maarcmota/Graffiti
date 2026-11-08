# PaintCore — resumo do plugin

## Visão geral

PaintCore é a camada-base de pintura da CW. A documentação incluída no projeto o descreve como código-base para Paint in 2D e Paint in 3D. Neste projeto, ele está em `Assets\Plugins\CW\PaintCore`, acompanhado por PaintIn3D e pela biblioteca compartilhada CW.Common.

O sistema pinta texturas associadas a materiais de objetos; não altera diretamente a geometria do mesh. Isso permite pintar superfícies 3D com UVs adequados, desde que renderer, material, slot de textura, shader e configuração de textura sejam compatíveis. Portanto, “qualquer superfície” depende da preparação do objeto e não significa suporte automático a qualquer material ou geometria.

## Conceitos principais

- **Objeto pintável:** `CwModel` representa um objeto com renderer. A superfície precisa de UVs utilizáveis.
- **Textura pintável:** `CwPaintableTexture` configura a textura associada a um slot do material, canal UV, grupo, tamanho, textura inicial e opções de salvar/carregar e undo/redo.
- **Pincel e comandos:** componentes como `CwPaintFill` submetem operações de pintura. Grupos, modos de mistura, cor, textura, opacidade e modificadores controlam o resultado.
- **Entrada e colisão:** os componentes de hit transformam contatos com objetos em coordenadas de pintura; ponteiros dão suporte a fontes de entrada do jogo.
- **Gerenciamento e medição:** `CwPaintableManager` agrupa operações de pintura. Contadores como `CwColorCounter`, `CwChannelCounter` e `CwChangeCounter` permitem medir a textura pintada.
- **Persistência e estados:** as texturas pintáveis oferecem configurações de salvamento/carregamento e undo/redo; a escolha do modo pode afetar memória e custo de redesenho.

## Relação entre os pacotes

- **CW.Common:** utilitários e dependências compartilhados.
- **PaintCore:** base de texturas, hits, comandos, estados, gerenciamento e medição.
- **PaintIn3D:** pacote de pintura 3D que referencia PaintCore e adiciona componentes e exemplos para a experiência de pintura em objetos 3D.

No projeto, o assembly `PaintCore` referencia `CW.Common` e `Unity.InputSystem`; o assembly `PaintIn3D` referencia `PaintCore` e `CW.Common`. Os exemplos e a documentação locais ficam dentro das pastas dos respectivos pacotes.

## Uso no jogo

1. Preparar o mesh com renderer e UVs adequados e conferir o slot de textura do material.
2. Configurar a textura pintável e os componentes de modelo/entrada necessários para o tipo de interação desejado.
3. Ajustar resolução, grupos, modo de mistura e comportamento de persistência ao caso de uso.
4. Testar no shader e no render pipeline usados pelo jogo; não presumir que todo material funcione sem ajustes.
5. Manter a lógica específica de Graffiti em scripts do jogo sempre que possível, em vez de alterar o código do fornecedor.

Resolução de textura e estratégia de undo/redo influenciam o uso de memória e desempenho. Testar em cenas representativas antes de definir os valores finais.

## Alterações locais conhecidas

Em `Assets\Plugins\CW\PaintCore\Required\Scripts\CwColor.cs`, o atributo `[SerializeField]` aplicado à classe interna `Contribution` foi trocado por `[System.Serializable]`. A primeira forma causava CS0592, pois `SerializeField` só pode ser aplicado a campos; a alteração permitiu compilar o assembly PaintCore. Alterações futuras em plugins de terceiros devem também ser registradas em `Context.md`, incluindo arquivo, mudança e motivo.

## Licença e redistribuição

- `Assets\Plugins\CW\Third-Party Notices.txt` documenta a fonte Varela Round sob SIL Open Font License 1.1. Esse aviso é para a fonte e **não define a licença do PaintCore, PaintIn3D ou CW.Common**.
- Os `package.json` locais identificam Carlos Wilkes como autor e indicam metadados de versão, mas não contêm os termos de uso do plugin.
- Não foi encontrada, na pasta local do plugin, uma licença ou EULA específica para os pacotes CW. Isso não significa que o uso seja proibido; significa que os direitos não podem ser confirmados apenas pelos arquivos presentes no projeto.
- Antes de modificar, distribuir ou publicar o jogo, consultar os termos associados à compra ou à fonte original do plugin. Confirmar especialmente os direitos de modificar o código, incluir os arquivos necessários no jogo final, usar por membros da equipe e redistribuir o código-fonte ou o pacote separadamente.
- Preservar os avisos de copyright/licença fornecidos. Não redistribuir o plugin como pacote independente sem autorização explícita nos termos aplicáveis.

Este resumo é uma referência técnica do projeto, não uma interpretação jurídica da licença.
