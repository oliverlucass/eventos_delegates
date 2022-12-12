using PlataformaCurso.Models;

public class MateriaService
{
    public delegate void m_event_handler(object m, MEventArgs m_args);
    public event m_event_handler m_event;


    private List<Materia> ListaDeMaterias = new List<Materia>();

    public void CriarMateria(List<Professor> professoresPossiveis)
    {
        Materia novaMateria;

        Console.WriteLine("Digite o nome da matéria");
        var nome = Console.ReadLine();

        if (!string.IsNullOrEmpty(nome))
        {
            var professorResponsavel = SelecionaProfessorResponsavel(professoresPossiveis);

            novaMateria = new Materia(nome, professorResponsavel);
            quando_criar_materia(novaMateria);
        }
    }

    private Professor? SelecionaProfessorResponsavel(List<Professor> professores)
    {
        Console.WriteLine("Escolha o professor responsável (SELECIONE A OPÇÂO)");

        for(int i = 0; i < professores.Count; i++) {
            Console.WriteLine($"{i+1} - {professores[i].Nome}");
        }

        var textoDigitado = Console.ReadLine();

        if(!string.IsNullOrEmpty(textoDigitado))
        {
            var indice = int.Parse(textoDigitado) - 1;
            return professores[indice];
        }

        return null;
    }

    public List<Materia> ObterTodos()
    {
        return this.ListaDeMaterias;
    }

    protected virtual void quando_criar_materia(Materia p_m)
    {
        if(m_event != null)
        {
            var arg=new MEventArgs(){ m = p_m };
            m_event(this, arg);
        }
    }
}