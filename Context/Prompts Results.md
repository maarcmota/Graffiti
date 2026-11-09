Sim — **não é obrigatório usar um material especial**. O material precisa ter uma propriedade de textura que o PaintIn3D possa atualizar, e essa propriedade precisa corresponder ao *Slot* configurado em `CwPaintableMeshTexture`. Também é essencial que a mesh tenha UVs válidos.

Encontrei duas coisas importantes na configuração atual. O objeto se chama `Paint Surface`, mas usa a mesh `Spaceship`:

1. **O collider não corresponde à mesh visível:** o `MeshFilter` usa `Spaceship`, mas o `MeshCollider` ainda usa `Map1`. O projétil pode acertar uma superfície diferente daquela que você vê, causando pintura deslocada ou inconsistente. No Inspector, confira se o `MeshCollider` usa a mesma mesh do `MeshFilter`.
2. **A pintura está configurada para UVs secundários:** o material usa o shader `Paint in 3D/Solid`, o slot está como `_AlbedoTex` e a coordenada está em `Second`. Nesse shader, `_AlbedoTex` é uma camada especial que usa o segundo canal de UVs. Se a nave não tiver esse canal corretamente desembrulhado, a pintura pode aparecer errada ou em partes inesperadas.

Para aprender, eu faria o teste mais simples primeiro: use um cubo ou uma mesh simples com `MeshRenderer`, `MeshFilter` e `MeshCollider` usando a mesma mesh. Adicione `CwPaintableMesh` e `CwPaintableMeshTexture`; depois escolha um slot que exista no material e a coordenada UV correspondente. Por exemplo, com um material URP Lit, normalmente o slot é `_BaseMap` e a coordenada é `Primary`. Com o material atual da CW, `_AlbedoTex` exige `Second` e UVs secundários válidos. O componente documenta o slot e o canal UV em `CwPaintableTexture.cs`; a configuração especial do shader está em `Solid.shader`.

Depois que o teste simples funcionar, ajuste a nave: confira os UVs do canal escolhido, alinhe o `MeshCollider` com a mesh visível e verifique se o `Group` da superfície corresponde ao grupo do componente de pintura do projétil. **Eu começaria corrigindo o collider `Map1`**, que está claramente diferente da mesh `Spaceship`. Não alterei a cena.



00 21 09 11 26 

Refatorei o fluxo de inicialização em `PaintBallBowStartup.cs` e acrescentei comentários explicativos a esse script e a `PaintBallProjectilePainter.cs`. Também documentei a proteção contra combo nulo em `ComboManager.cs` e reorganizei a seção do PaintBall em `Context.md`, incluindo os limites da validação.

**Verificação:** o Unity concluiu a compilação com sucesso. Não fiz um novo teste de disparo em Play Mode.
