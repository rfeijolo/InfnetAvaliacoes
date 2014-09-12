using Avaliacoes.Application.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacoes.Application.UseCases
{
    public class MessageFactory
    {
        public static Message Compose(Message.Status status, params Message[] msgs)
        {
            string msg = "";
            for (int i = 0; i < msgs.Length - 1; i++)
            {
                msg += msgs[i].CurrentMessage + " ";
            }

            return new Message(msg, status);
        }

        public static Message AvaliacaoIndisponivel()
        {
            return new Message("A avaliação solicitada se encontra indisponível.", Message.Status.Failure);
        }

        public static Message CadastroEfetuadoSucesso()
        {
            return new Message("Cadastro efetuado com sucesso.", Message.Status.Success);
        }

        public static Message CadastroNaoEfetuado()
        {
            return new Message("Não foi possível efetuar o cadastro.", Message.Status.Failure);
        }

        internal static Message CampoUltrapassaLimiteCaracteres(string campo, int limite)
        {
            return new Message(String.Format("Campo {0} ultrapassa o limite de {1} caracteres .", campo, limite), Message.Status.Failure);
        }
    }
}
